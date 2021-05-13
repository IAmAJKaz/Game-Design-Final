using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {

    public Animator anim;
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("DeathBarrier")) {;
            //anim.SetBool("isDead", true);

            Destroy(gameObject);
            LevelManager.instance.Respawn();
            //anim.SetBool("isDead", false);
        }
    }

    
}
