using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static AudioClip playerDeathSound, shootSound, enemyDeathSound, lifeUpSound;
    static AudioSource audioSrc;

    private void Start() {
        playerDeathSound = Resources.Load<AudioClip>("playerDeath");
        shootSound = Resources.Load<AudioClip>("pew1");
        enemyDeathSound = Resources.Load<AudioClip>("enemyDeath");
        lifeUpSound = Resources.Load<AudioClip>("lifeUp");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip) {
        switch (clip) {
            case "playerDeath":
                audioSrc.PlayOneShot(playerDeathSound);
                break;
            case "shoot":
                audioSrc.PlayOneShot(shootSound);
                break;
            case "enemyDeath":
                audioSrc.PlayOneShot(enemyDeathSound);
                break;
            case "lifeUp":
                audioSrc.PlayOneShot(lifeUpSound);
                break;
        }
    }
}
