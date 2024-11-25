using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallestaHit : MonoBehaviour
{
    public GameObject BallestaArrow;
    public float distance;
    private Animator ballestaAnimator;
    private bool canFire;

    // Start is called before the first frame update
    void Start()
    {
        ballestaAnimator = GetComponentInParent<Animator>();
        canFire = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.up * distance, Color.green);

        Ray ray = new Ray(transform.position, transform.up);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, distance);
        if (hit && hit.collider.gameObject.CompareTag("Player") && canFire)
        {
            StartCoroutine(Shoot());
        }

        
    }

    private IEnumerator Shoot() 
    {
        canFire = false;
        Instantiate(BallestaArrow, transform.position, transform.rotation);
        ballestaAnimator.SetBool("shooting", true);
        yield return new WaitForSeconds(0.1f);
        ballestaAnimator.SetBool("shooting", false);
        canFire = true;
    }
}
