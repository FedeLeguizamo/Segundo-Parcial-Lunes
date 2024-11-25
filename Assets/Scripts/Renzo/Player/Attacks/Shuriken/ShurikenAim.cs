using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenAim : MonoBehaviour
{

    [SerializeField] private float fireTimer = 2f;
    [SerializeField] private bool canfire;

    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);


        if (Input.GetKeyDown(KeyCode.E) && canfire)
        {
            StartCoroutine(shooting());
        }

    }
    private IEnumerator shooting()
    {
        canfire = false;
        Instantiate(bullet, bulletTransform.position, transform.GetChild(0).rotation);
        yield return new WaitForSeconds(fireTimer);
        canfire = true;
    }
}
