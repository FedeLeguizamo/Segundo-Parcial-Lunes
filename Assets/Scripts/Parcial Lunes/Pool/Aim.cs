using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Aim : MonoBehaviour
{
    private Camera m_Camera;
    public GameObject Player;
    public GameObject Bullet; 
    public Transform BulletTransform;
    private float Timer;
    public float TimeBetweenFire;
    private bool canFire = true;

    private Queue<GameObject> bulletPool = new Queue<GameObject>(); 

    void Start()
    {
        m_Camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        
        for (int i = 0; i < 10; i++)
        {
            GameObject bullet = Instantiate(Bullet);
            bullet.SetActive(false);
            bulletPool.Enqueue(bullet);
        }
    }

    void FixedUpdate()
    {
        if (canFire)
        {
            Fire();
        }

        if (!canFire)
        {
            Timer += Time.deltaTime;
            if (Timer > TimeBetweenFire)
            {
                Timer = 0;
                canFire = true;
            }
        }
    }

    void Fire()
    {
        canFire = false;

        GameObject bullet;

        
        if (bulletPool.Count > 0)
        {
            bullet = bulletPool.Dequeue();
        }
        else
        {
            bullet = Instantiate(Bullet);
        }

        bullet.transform.position = BulletTransform.position;
        bullet.transform.rotation = BulletTransform.rotation;
        bullet.SetActive(true);

        
        var bulletScript = bullet.GetComponent<Bullet_Fede>();
        if (bulletScript != null)
        {
            bulletScript.Initialize(Player, bulletScript.speed);
        }

        
        Invoke(nameof(ReturnBulletToPool), 2f);
    }

    void ReturnBulletToPool()
    {
        foreach (var bullet in bulletPool)
        {
            if (bullet != null && bullet.activeInHierarchy)
            {
                bullet.SetActive(false);
                bulletPool.Enqueue(bullet);
            }
        }
    }
}
