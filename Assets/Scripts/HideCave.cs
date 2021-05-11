using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HideCave : MonoBehaviour {

    private TilemapRenderer tmRenda;
    private TilemapCollider2D tmCola;
    private CaveTrigger caveTrig;

    private void Start() {
        tmRenda = GetComponent<TilemapRenderer>();
        tmCola = GetComponent<TilemapCollider2D>();
        caveTrig = FindObjectOfType<CaveTrigger>();
    }


    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            //tmCola.enabled = false;

            caveTrig.tmCol.enabled = true;
            caveTrig.tmRend.enabled = true;
        }
    }


}
