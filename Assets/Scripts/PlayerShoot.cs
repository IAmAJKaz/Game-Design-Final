using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerShoot : MonoBehaviour {
    public float fireRate = 0.2f;
    public Transform firingPoint;
    public GameObject bulletPrefab;

    float timeUntilFire;

    PlayerMovement pm;

    private void Start() {
        pm = gameObject.GetComponent<PlayerMovement>();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0) && timeUntilFire < Time.time && pm.ctrlActive && !PauseMenu.gameIsPaused) {
            SoundManager.PlaySound("shoot");
            Shoot();
            timeUntilFire = Time.time + fireRate;
        }
    }

    void Shoot() {
        float angle = pm.isFacingRight ? 0f : 180f;
        Instantiate(bulletPrefab, firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
    }

    IEnumerator destroyBullet()
    {
        yield return new WaitForSeconds(5f);
        Destroy(bulletPrefab);
    }
}
