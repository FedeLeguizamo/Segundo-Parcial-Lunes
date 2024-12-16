using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
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

    private Queue<BulletDardo> bulletPool = new Queue<BulletDardo>(); 
    private BulletPrototype bulletPrototype; 

    void Start()
    {
        m_Camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        
        bulletPrototype = new BulletPrototype(Bullet);

        
        for (int i = 0; i < 10; i++)
        {
            GameObject bulletObj = bulletPrototype.Clone(); 
            BulletDardo bullet = bulletObj.GetComponent<BulletDardo>();
            IDardo dardp =  new BulletWrapper(bulletObj.GetComponent<BulletDardo>());

            if (bullet != null)
            {
                bulletObj.SetActive(false);
                bulletPool.Enqueue(bullet);
            }
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

        BulletDardo bullet;

        
        if (bulletPool.Count > 0)
        {
            bullet = bulletPool.Dequeue();
        }
        else
        {
            GameObject bulletObj = bulletPrototype.Clone(); 
            bullet = bulletObj.GetComponent<BulletDardo>();
        }

        if (bullet != null)
        {
            bullet.transform.position = BulletTransform.position;
            bullet.transform.rotation = BulletTransform.rotation;
            bullet.Initialize(Player, this); 
            bullet.gameObject.SetActive(true);

            
            StartCoroutine(ReturnBulletToPool(bullet, 2f));
        }
    }

    public void ReturnBulletToPool(BulletDardo bullet)
    {
        if (bullet.gameObject.activeInHierarchy)
        {
            bullet.gameObject.SetActive(false);
            bulletPool.Enqueue(bullet);
        }
    }

    private IEnumerator ReturnBulletToPool(BulletDardo bullet, float delay)
    {
        yield return new WaitForSeconds(delay);

        
        if (bullet == null || bullet.gameObject == null)
        {
            yield break; 
        }

        if (bullet.gameObject.activeInHierarchy)
        {
            ReturnBulletToPool(bullet);
        }
    }
}
