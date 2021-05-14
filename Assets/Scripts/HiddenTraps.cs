using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HiddenTraps : MonoBehaviour {

    public TilemapRenderer tmRend;
    public TilemapCollider2D tmCol;

    private void Start() {
        tmRend = GetComponent<TilemapRenderer>();
        tmCol = GetComponent<TilemapCollider2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            tmCol.enabled = false;
            tmRend.enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        tmCol.enabled = true;
        tmRend.enabled = true;
    }

    public void hideCave() {
        tmCol.enabled = true;
        tmRend.enabled = true;
    }
}
