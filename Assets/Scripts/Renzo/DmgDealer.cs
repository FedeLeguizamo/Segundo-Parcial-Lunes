using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgDealer : MonoBehaviour
{
    public float dmg;
    public string Target;
    public string Target2;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.CompareTag(Target) || collision.CompareTag(Target2))
        {
            collision.gameObject.GetComponent<Health>().dmgTaken += dmg;
        }
    }
}
