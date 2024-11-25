using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    
    private float timeBtwShots;
    public float startTimeBtwShots;

    public Transform player;
    public GameObject bullet;
    private IEnemyState currentState; // Estado actual

    private IShootingStrategy shootingStrategy;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        SetState(new ChaseState()); // Iniciar en el estado de persecución
        timeBtwShots = startTimeBtwShots;
        
        shootingStrategy = new StandardShootingStrategy();
    }

    void Update()
    {
        // Determinar el estado según la distancia al jugador
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance > stoppingDistance && !(currentState is ChaseState))
        {
            SetState(new ChaseState());
        }
        else if (distance <= stoppingDistance && distance > retreatDistance && !(currentState is IdleState))
        {
            SetState(new IdleState());
        }
        else if (distance <= retreatDistance && !(currentState is RetreatState))
        {
            SetState(new RetreatState());
        }
        
        // Cambiar estrategia si el jugador está cerca
        if (distance < 5f)
        {
            SetShootingStrategy(new RapidShootingStrategy());
        }
        else
        {
            SetShootingStrategy(new StandardShootingStrategy());
        }

        // Ejecutar lógica del estado actual
        currentState.UpdateState(this);
        
        if (timeBtwShots <= 0)
        {
            shootingStrategy.Shoot(bullet, transform, player);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
    
    public void SetShootingStrategy(IShootingStrategy newStrategy)
    {
        shootingStrategy = newStrategy;
    }

    public void SetState(IEnemyState newState)
    {
        // Salir del estado actual, si existe
        if (currentState != null)
        {
            currentState.ExitState(this);
        }

        // Cambiar al nuevo estado
        currentState = newState;
        currentState.EnterState(this);
    }
}