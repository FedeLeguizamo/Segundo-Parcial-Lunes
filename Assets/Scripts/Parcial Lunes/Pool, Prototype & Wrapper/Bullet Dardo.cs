using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDardo : MonoBehaviour
{
    GameObject target;
    public float speed;
    Rigidbody2D bulletRB;
    private Aim aimReference;
    public BulletData bulletData;

    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");

        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);

        float rotZ = Mathf.Atan2(-moveDir.y, -moveDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ + 90);
    }
    
    public void Initialize(GameObject target, Aim aim)
    {
        this.target = target;
        this.aimReference = aim;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Health>().dmgTaken += bulletData.damage;
            
            aimReference.ReturnBulletToPool(this);
        }
    }
}
