using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Bullet_Fede : MonoBehaviour
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

        float rot = Mathf.Atan2(-moveDir.y, -moveDir.x) *Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
        
        Destroy(this.gameObject, 2);

    }

    void FixedUpdate()
    {
        
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
