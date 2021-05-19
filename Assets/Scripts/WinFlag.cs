using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WinFlag : MonoBehaviour {

    public LevelBeat lvlBeat;
    private PlayerMovement pm;
    
    [Header("WinScreen")]
    public TMP_Text winScreenMoneyText;
    public TMP_Text winScreenKillsText;

    private void Start() {
        pm = FindObjectOfType<PlayerMovement>();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            pm.ctrlActive = false;
            lvlBeat.WinScreen();
            winScreenMoneyText.text = "$" + LevelManager.instance.getMoney();
            winScreenKillsText.text = "" + LevelManager.instance.getKillCount();            
        }
    }
}
