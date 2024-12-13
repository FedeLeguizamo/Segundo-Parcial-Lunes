using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
GameObject target;

public float speed;

Rigidbody2D bulletRB;

    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        
        target = GameObject.FindGameObjectWithTag("Player");
        
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
        
        float rotZ = Mathf.Atan2(-moveDir.y, -moveDir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ + 90);  

        Destroy(this.gameObject, 2);

    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Health>().dmgTaken += 10;
        }

        if (other.CompareTag("Player"))
        {
            DestroyBullet();
        }

        //if (other.CompareTag("Player") && other.gameObject.GetComponent<PlayerHealth>().health <= 0)
        //{
        //    Destroy(other.gameObject);
        //}
    }


    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
