using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour 
{
    private Animator barrilanim;
    private Rigidbody2D collrb;
    public float power = 24.0f;

    // Start is called before the first frame update
    void Start()
    {
        barrilanim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
            
        

        
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if ( collider.gameObject.CompareTag("Enemy"))
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
            this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            collrb = collider.gameObject.GetComponent<Rigidbody2D>();
            collider.gameObject.GetComponent<Health>().dmgTaken += 100;
            collrb.AddForce(-(transform.position - collider.transform.position) * power);
            barrilanim.SetBool("trigger", true);

            AudioManager audioManager = ServiceLocator.GetService<AudioManager>();
            audioManager.Play("Explosion");

            Destroy(this.gameObject, 1);
        }
    }

}
