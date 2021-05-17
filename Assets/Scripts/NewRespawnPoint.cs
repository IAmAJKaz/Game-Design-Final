using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewRespawnPoint : MonoBehaviour {

    //public float xPos;
    //public float yPos;
    public GameObject respawnPt;

    private void OnTriggerEnter2D(Collider2D collision) {
        //respawnPt.transform.position = new Vector2(xPos, yPos);
        //respawnPt.transform.position = gameObject.transform.position;
        respawnPt.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 0.2f);

        //change to a dif sprite
    }

}
