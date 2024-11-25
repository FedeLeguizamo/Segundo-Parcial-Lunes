using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Aim : MonoBehaviour
{

    private Camera m_Camera;
    public GameObject Player; 
    public GameObject Bullet; 
    public Transform BulletTransform;
    private float Timer;
    public float TimeBetweenFire;
    private float Rotation;
    public float Distance;
    public bool canFire;

    // Start is called before the first frame update
    void Start()
    {
        m_Camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Raycast
        Vector3 rotation = (Player.transform.position - transform.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, rotation * Distance); 

        if (hit && canFire)
        {
            canFire = false;    
            Instantiate(Bullet, BulletTransform.position, Quaternion.identity); 
        }

        if (!canFire)
        {
            Timer += Time.deltaTime; 
            if (Timer > TimeBetweenFire) { 
                Timer = 0;
                canFire = true;
            }
        }
        ////Pasa radianes a grados, busca posicion player con respoecto a la del objeto 
        //float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        //transform.rotation = Quaternion.Euler(0, 0, rotZ * ); 

        Rotation = Rotation + 0.8f;

        if (Rotation > 360)
        {
            Rotation = 0;
        }
    
        transform.rotation = Quaternion.Euler(0, 0, Rotation);

        
        

        
    }
}
