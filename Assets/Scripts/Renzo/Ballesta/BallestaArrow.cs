using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallestaArrow : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Vector3 dir = transform.GetChild(0).position - transform.position;
        rb.velocity = new Vector2(dir.x, dir.y).normalized * speed;

        Destroy(this.gameObject, 3);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
        
    }
}
