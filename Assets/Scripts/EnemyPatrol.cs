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

    RaycastHit2D hit;
    
    private void Update() {
        hit = Physics2D.Raycast(groundCheck.position, -transform.up, 1f, groundLayers);
    }

    private void FixedUpdate() {
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

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Bullet")) {
            //GetComponent<Renderer>().material.color = Color.red;
            hp--;
            if(hp == 0) {
                Destroy(gameObject);
            }
           //GetComponent<Renderer>().material.color = Color.white;
        }
    }

}
