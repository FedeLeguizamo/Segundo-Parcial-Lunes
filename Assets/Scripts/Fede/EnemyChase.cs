using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public Animator Enemyanim; 
    private float distance; 

    // Start is called before the first frame update
    void Start()
    {
        Enemyanim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance= Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position; 

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

        Enemyanim.SetFloat("Speed", direction.sqrMagnitude);
        Enemyanim.SetFloat("Horizontal", direction.x);
        Enemyanim.SetFloat("Vertical", direction.y);
    }
}
