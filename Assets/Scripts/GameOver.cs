using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
    
    public void LoseScreen() {
        gameObject.SetActive(true);
    }
    public void MainMenuScreen() {
        SceneManager.LoadScene("Menu");
    }

}
