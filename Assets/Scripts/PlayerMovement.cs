using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float movementSpeed;
    public Rigidbody2D rb;
    public Animator anim;

    private LevelManager theLM;

    //Death variables
    [HideInInspector]
    public bool ctrlActive;
    private bool isDead;
    private CapsuleCollider2D playerCol;
    public GameObject[] childObjs;
    public float shockForce;

    public float jumpForce = 25f;
    public Transform feet;
    public LayerMask groundLayers;

    [HideInInspector] public bool isFacingRight = true;

    float mx;

    private void Start() {
        theLM = FindObjectOfType<LevelManager>();
        playerCol = GetComponent<CapsuleCollider2D>();
        ctrlActive = true;
    }

    private void Update() {
        if (ctrlActive) {
            mx = Input.GetAxisRaw("Horizontal");

            if (Input.GetButtonDown("Jump") && IsGrounded()) {
                Jump();
            }
            if (Mathf.Abs(mx) > 0.05f) {
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
        }
        anim.SetBool("isGrounded", IsGrounded());
    }

    private void FixedUpdate() {
        Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);
        rb.velocity = movement;
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

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("DeathBarrier")) {
            Destroy(gameObject);
            LevelManager.instance.Respawn();
        }
        else if (collision.gameObject.CompareTag("Enemy")) {
            SoundManager.PlaySound("playerDeath");
            PlayerDeath();
        }
    }

    void PlayerDeath() {
        isDead = true;
        anim.SetBool("isDead", isDead);
        ctrlActive = false;
        playerCol.enabled = false;
        foreach(GameObject child in childObjs) {
            child.SetActive(false);
        }
        rb.gravityScale = 2.5f;
        rb.AddForce(transform.up * shockForce, ForceMode2D.Impulse);
        StartCoroutine("PlayerRespawn");
    }

    IEnumerator PlayerRespawn() {
        yield return new WaitForSeconds(1.5f);
        isDead = false;
        anim.SetBool("isDead", isDead);  
        playerCol.enabled = true;
        foreach (GameObject child in childObjs) {
            child.SetActive(true);
        }
        rb.gravityScale = 5f;
        yield return new WaitForSeconds(0.1f);
        ctrlActive = true;
        theLM.Respawn();
    }
    
}
