using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CaveTrigger : MonoBehaviour {

    public TilemapRenderer tmRend;
    public TilemapCollider2D tmCol;

    private void Start() {
        tmRend = GetComponent<TilemapRenderer>();
        tmCol = GetComponent<TilemapCollider2D>();
    }
    

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            tmCol.enabled = false;
            tmRend.enabled = false;
        }
    }
    
    public void hideCave() {
        tmCol.enabled = true;
        tmRend.enabled = true;
    }
}
