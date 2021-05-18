using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUp : MonoBehaviour {

    private LevelManager theLM;

    void Start() {
        theLM = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            SoundManager.PlaySound("lifeUp");
            theLM.AddLife();
            Destroy(gameObject);
        }
    }
}
