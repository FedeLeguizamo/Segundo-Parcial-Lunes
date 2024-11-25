using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ShurikenScript : MonoBehaviour
{
    //[SerializeField] private float despTime = 2;
    //private Vector3 mousePos;
    //private Vector3 direction;
    //private Camera mainCam;
    //private Rigidbody2D rb;
    //private Rigidbody2D collrb;
    //public float power;
    //public float hitPower = 50;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    //    rb = GetComponent<Rigidbody2D>();
    //    mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
    //    Vector3 direction = mousePos - transform.position;
    //    Vector3 rotation = transform.position - mousePos;
    //    rb.velocity = new Vector2(direction.x, direction.y).normalized * power;
    //    float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
    //    transform.rotation = Quaternion.Euler(0, 0, rot + 90);

    //    Destroy(this.gameObject, despTime);
    //}



    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (!collision.gameObject.CompareTag("Player"))
    //    {
    //        if (collision.gameObject.CompareTag("MapPart"))
    //        {
    //            collrb = collision.gameObject.GetComponent<Rigidbody2D>();
    //            collrb.constraints = ~RigidbodyConstraints2D.FreezePosition;
    //            collrb.AddForce((mousePos - transform.position).normalized * hitPower);
    //        }
    //        Destroy(this.gameObject);
    //    }
    //}

    [SerializeField] private float despTime = 2;
    private Vector3 dir;
    private Rigidbody2D rb;
    private Rigidbody2D collrb;
    public float speed;
    public float hitPower = 50;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        dir = transform.GetChild(0).position - transform.position;
        rb.velocity = new Vector2(dir.x, dir.y).normalized * speed;

        Destroy(this.gameObject, despTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("EnemyAssets"))
        {
            if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("MovalbeAsset"))
            {
                collrb = collision.gameObject.GetComponent<Rigidbody2D>();
                collrb.constraints = ~RigidbodyConstraints2D.FreezePosition;
                collrb.AddForce(new Vector2(dir.x, dir.y).normalized * hitPower);
            }
            Destroy(this.gameObject);
        }
    }
}

