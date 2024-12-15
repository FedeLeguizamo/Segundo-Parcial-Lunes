using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Bullet_Fede : MonoBehaviour
{
    private Rigidbody2D bulletRB;
    private GameObject target;
    public float speed;

    void Awake()
    {
        bulletRB = GetComponent<Rigidbody2D>();
    }

    
    public void Initialize(GameObject target, float speed)
    {
        this.target = target;
        this.speed = speed;

        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = moveDir;

        float rot = Mathf.Atan2(-moveDir.y, -moveDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    
    public void ResetBullet()
    {
        bulletRB.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Health>().dmgTaken += 10;
            ResetBullet(); 
        }
    }
}

