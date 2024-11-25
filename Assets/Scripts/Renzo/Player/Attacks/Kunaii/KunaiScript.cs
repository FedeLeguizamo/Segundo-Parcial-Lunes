using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KunaiScript : MonoBehaviour
{
    [SerializeField] private float despTime = 2;
    private Rigidbody2D rb;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Vector3 dir = transform.GetChild(0).position - transform.position;
        rb.velocity = new Vector2(dir.x, dir.y).normalized * speed;

        Destroy(this.gameObject, despTime);
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("EnemyAssets"))
        {
            Destroy(this.gameObject);
        }
    }
}
