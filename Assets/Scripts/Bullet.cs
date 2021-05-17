using UnityEngine;

public class Bullet : MonoBehaviour {
    public float bulletSpeed = 15f;
    public float bulletDamage = 50f;
    public Rigidbody2D rb;

    private void FixedUpdate() {
        rb.velocity = transform.right * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Destroy(gameObject);       
    }
}
