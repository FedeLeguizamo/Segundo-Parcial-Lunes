using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed = 3f;
    [SerializeField] private float dashCooldown = 4f;
    [SerializeField] private float dashPower = 24f;

    private bool canDash = true;
    private bool isDashing;
    private float dashTime = 0.1f;
    
    private float moveY;
    private float moveX;

    private Rigidbody2D playerRb;
    private Vector2 moveInput;
    private Animator playerAnimator;
    private TrailRenderer tr;


    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        tr = GetComponent<TrailRenderer>();
    }


    void Update()
    {
        //movement
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY).normalized;

        playerAnimator.SetFloat("Horizontal", moveX);
        playerAnimator.SetFloat("Vertical", moveY);
        playerAnimator.SetFloat("speed", moveInput.sqrMagnitude);

        //dash
        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash());
        }
    }


    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        playerRb.velocity = new Vector2(moveX * dashPower, moveY * dashPower);
        tr.emitting = true;
        yield return new WaitForSeconds(dashTime);
        tr.emitting = false;
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    
    private void FixedUpdate()
    {
        if (!isDashing)
        {
            playerRb.velocity = new Vector3(moveInput.x * speed * Time.deltaTime, moveInput.y * speed * Time.deltaTime);
        }
    }
}
