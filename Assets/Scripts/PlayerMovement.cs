using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float movementSpeed;
    public Rigidbody2D rb;
    public Animator anim;

    public float jumpForce = 25f;
    public Transform feet;
    public LayerMask groundLayers;

    /* variables for dash function
    public float dashDistance = 25f;
    bool isDashing;
    float doubleTapTime;
    KeyCode lastKeyCode;
    */

    //Teleport Variables
    public bool teleport;
    public LayerMask whatIsTele;

    [HideInInspector] public bool isFacingRight = true;

    float mx;

    private void Update() {
        mx = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded()) {
            Jump();
        }

        if(Mathf.Abs(mx) > 0.05f) {
            anim.SetBool("isRunning", true);
        }
        else {
            anim.SetBool("isRunning", false);
        }

        if (mx > 0f) {
            transform.localScale = new Vector3(1.75f, 1.75f, 1.75f);
            isFacingRight = true;
        }
        else if (mx < 0f) {
            transform.localScale = new Vector3(-1.75f, 1.75f, 1.75f);
            isFacingRight = false;
        }

        /* Glide function
        if(!IsGrounded() && Input.GetKey(KeyCode.Space)) {
            
            change gravity here?
        }
        else {
            set gravity back to normal here?
        }
        */

        /*
        //Dashing left
        if (Input.GetKeyDown(KeyCode.A)) {
            if(doubleTapTime > Time.time && lastKeyCode == KeyCode.A) {
                StartCoroutine(Dash(-1f));
            }
            else {
                doubleTapTime = Time.time + 0.3f;
            }
            lastKeyCode = KeyCode.A;
        }
        //Dashing right
        if (Input.GetKeyDown(KeyCode.D)) {
            if (doubleTapTime > Time.time && lastKeyCode == KeyCode.D) {
                StartCoroutine(Dash(1f));
            }
            else {
                doubleTapTime = Time.time + 0.3f;
            }
            lastKeyCode = KeyCode.D;
        }
        */


        anim.SetBool("isGrounded", IsGrounded());
    }

    private void FixedUpdate() {
        //if (!isDashing) {
            Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);

            rb.velocity = movement;
        //}
    }

    void Jump() {
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
        
        rb.velocity = movement;
    }

    public bool IsGrounded() {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);

        if (groundCheck != null) {
            return true;
        }

        return false;
    }

    /*  DASH FUNCTION:
    IEnumerator Dash (float direction) {
        isDashing = true;
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(new Vector2(dashDistance * direction, 0f), ForceMode2D.Impulse);
        float gravity = rb.gravityScale;
        rb.gravityScale = 0;
        yield return new WaitForSeconds(0.3f);
        isDashing = false;
        rb.gravityScale = gravity;
    }
    */
}
