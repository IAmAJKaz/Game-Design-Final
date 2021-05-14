using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
    public static LevelManager instance;

    public Transform respawnPoint;
    public GameObject playerPrefab;

    public CinemachineVirtualCameraBase cam;

    [Header("Lives")]
    public int playerLives;
    public Text livesUI;


    [Header("Currency")]
    public int currency = 0;
    public Text currencyUI;

    private void Awake() {
        instance = this;
        livesUI.text = "" + playerLives;
    }

    public void Respawn() {
        playerLives--;
        livesUI.text = "" + playerLives;
        if (playerLives >= 0) {
            GameObject player = Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
            cam.Follow = player.transform;
        }
        else {
            livesUI.text = "0";
            Debug.Log("You lost, haha you suck");
        }
    }

    public void IncreaseCurrency(int amount) {
        currency += amount;
        currencyUI.text = "$" + currency;
    }
    public void AddLife() {
        playerLives++;
        livesUI.text = "" + playerLives;
    }
    public void TakeLife() {
        playerLives--;
    }
}

