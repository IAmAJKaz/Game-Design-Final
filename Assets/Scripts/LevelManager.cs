using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour {
    public static LevelManager instance;

    public Transform respawnPoint;
    public GameObject playerPrefab;

    public CinemachineVirtualCameraBase cam;

    public GameOver gameOver;

    [Header("Lives")]
    public int playerLives;
    public Text livesUI;

    [Header("Currency")]
    public int currency = 0;
    public Text currencyUI;
    
    [Header("LoseScreen")]
    public TMP_Text endScreenCurrencyText;
    public TMP_Text endScreenKillsText;
    

    private int enemiesKilled;

    private void Awake() {
        instance = this;
        livesUI.text = "x" + playerLives;
    }

    public void Respawn() {
        playerLives--;
        livesUI.text = "" + playerLives;
        if (playerLives > 0) {
            GameObject player = Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
            cam.Follow = player.transform;
        }
        else {
            gameOver.LoseScreen();
            endScreenCurrencyText.text = "$" + currency;
            endScreenKillsText.text =  "" + enemiesKilled;
        }
    }

    public void IncreaseCurrency(int amount) {
        currency += amount;
        currencyUI.text = "$" + currency;
    }
    public void AddLife() {
        playerLives++;
        livesUI.text = "x" + playerLives;
    }
    public void TakeLife() {
        playerLives--;
    }
    public void AddKill() {
        enemiesKilled++;
    }
    public int getKillCount() {
        return enemiesKilled;
    }
    public int getMoney() {
        return currency;
    }
}

