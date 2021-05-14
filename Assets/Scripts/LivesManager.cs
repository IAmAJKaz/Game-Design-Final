using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour {

    public int playerLives;
    public Text livesUI;

    void Start() {
        playerLives = PlayerPrefs.GetInt("CurrentLives");
    }
    private void Awake() {
        livesUI.text = "" + playerLives;
    }


    void Update() {
        livesUI.text = "x " + playerLives;
        /*if (playerLives < 1) {
            StartCoroutine("QueGameOver");
        }*/
    }

    public void TakeLife() {
        playerLives--;
        //PlayerPrefs.SetInt("CurrentLives", playerLives);
    }

    public void AddLife() {
        playerLives++;
        //PlayerPrefs.SetInt("CurrentLives", playerLives);
    }

    

}
