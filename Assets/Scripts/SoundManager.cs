using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static AudioClip playerDeathSound, shootSound, enemyDeathSound, lifeUpSound, moneyCollect1, moneyCollect2;
    static AudioSource audioSrc;

    private void Start() {
        playerDeathSound = Resources.Load<AudioClip>("playerDeath");
        shootSound = Resources.Load<AudioClip>("pew1");
        enemyDeathSound = Resources.Load<AudioClip>("enemyDeath");
        lifeUpSound = Resources.Load<AudioClip>("lifeUp");
        moneyCollect1 = Resources.Load<AudioClip>("money1");
        moneyCollect2 = Resources.Load<AudioClip>("money2");

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
            case "money":
                int ran = Random.Range(0, 2);
                if (ran == 0)
                    audioSrc.PlayOneShot(moneyCollect1);
                else
                    audioSrc.PlayOneShot(moneyCollect2);
                break;
        }
    }
}
