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
    
    private EnemyStateMachine stateMachine; 

    private IShootingStrategy shootingStrategy;
    
    
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        stateMachine = new EnemyStateMachine(); 
        stateMachine.SetState(new ChaseState(), this); 
        
        timeBtwShots = startTimeBtwShots;
        shootingStrategy = new StandardShootingStrategy();
    }

    void Update()
    {
        stateMachine.Update(this);
        
        
        float distance = Vector2.Distance(transform.position, player.position);
        
        
        if (distance < 5f)
        {
            SetShootingStrategy(new RapidShootingStrategy());
        }
        else
        {
            SetShootingStrategy(new StandardShootingStrategy());
        }
        
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
}