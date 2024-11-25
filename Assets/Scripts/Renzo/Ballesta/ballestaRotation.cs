using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballestaRotation : MonoBehaviour
{
    private Rigidbody2D ballestaRb;

    // Start is called before the first frame update
    void Start()
    {
        ballestaRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, 0.1f, Space.Self);
    }
}
