using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee_enemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    [SerializeField] private float attackSpeed = 1f;
    [SerializeField] private float attackDamage = 15f;
    private float attackCooldown = 0f;

    private Rigidbody2D rb;
    public Transform player;

    private Animator enemy_animator;

    private IAttackStrategy attackStrategy;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy_animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        // Inicializamos la estrategia de ataque como cuerpo a cuerpo
        attackStrategy = new MeleeAttackStrategy();
    }

    private void FixedUpdate()
    {
        // Animaciones del enemigo
        enemy_animator.SetBool("isMoving", true);
        enemy_animator.SetFloat("moveX", player.position.x - transform.position.x);
        enemy_animator.SetFloat("moveY", player.position.y - transform.position.y);

        // Movimiento del enemigo
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (distanceToPlayer <= stoppingDistance && distanceToPlayer > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (distanceToPlayer <= retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Usamos la estrategia para atacar
            if (Time.time >= attackCooldown)
            {
                attackStrategy.Attack(gameObject, other.gameObject, attackDamage);
                attackCooldown = Time.time + 1f / attackSpeed;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Dirección del knockback desde el player al enemigo
            Vector2 knockbackDirection = (transform.position - other.transform.position).normalized;
            rb.AddForce(knockbackDirection * 10f, ForceMode2D.Impulse);
        }
    }

    public void SetAttackStrategy(IAttackStrategy newStrategy)
    {
        attackStrategy = newStrategy;
    }
}

