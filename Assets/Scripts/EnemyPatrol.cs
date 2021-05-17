using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {
    public float speed = 2f;
    public Rigidbody2D rb;
    public LayerMask groundLayers;

    public Transform groundCheck;

    bool isFacingRight = true;
    public int hp = 2;

    public Animator anim;

    //Death Variables
    private bool isDead;
    private Collider2D enemyCol;
    public float shockForce;
    private bool ctrlActive;

    RaycastHit2D hit;

    private void Start() {
        enemyCol = GetComponent<Collider2D>();
        ctrlActive = true;
    }
    private void Update() {
        hit = Physics2D.Raycast(groundCheck.position, -transform.up, 1f, groundLayers);
    }

    private void FixedUpdate() {
        if (ctrlActive) {
            if (hit.collider != false) {
                if (isFacingRight) {
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                }
                else {
                    rb.velocity = new Vector2(-speed, rb.velocity.y);
                }
            }
            else {
                isFacingRight = !isFacingRight;
                transform.localScale = new Vector3(-transform.localScale.x, 1.75f, 1.75f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Bullet")) {
            hp--;
            if(hp <= 0) {
                EnemyDeath();
            }
        }
    }

    private void EnemyDeath() {
        LevelManager.instance.AddKill();
        isDead = true;
        anim.SetBool("isDead", isDead);
        enemyCol.enabled = false;
        ctrlActive = false;
        rb.AddForce(transform.up * shockForce, ForceMode2D.Impulse);
        StartCoroutine("death");
    }
    
    IEnumerator death() {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

}
