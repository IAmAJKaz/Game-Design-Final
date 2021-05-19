using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewRespawnPoint : MonoBehaviour {

    public GameObject respawnPt;
    public Animator anim;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            respawnPt.transform.position = new Vector2(gameObject.transform.position.x + 1f, gameObject.transform.position.y);
            anim.SetBool("isCollected", true);
        }

    }

}
