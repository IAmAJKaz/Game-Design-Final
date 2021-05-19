using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelBeat : MonoBehaviour {
    public void WinScreen() {
        gameObject.SetActive(true);
    }
    public void MainMenuScreen() {
        SceneManager.LoadScene("Menu");
    }
    
}
