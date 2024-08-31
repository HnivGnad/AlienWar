using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shooting : MonoBehaviour {
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletForce;
    [SerializeField] Transform bulletPos;

    [SerializeField] float damagePlayer = 20f;
    
    [SerializeField] float cooldownShoot = 2f;

    [SerializeField] AudioSource audioShoot;
    float timer;
    void Start() {
        timer = cooldownShoot;
    }

    void Update() {
        SetCoolDown(cooldownShoot);
    }
    void Shoot() {
        GameObject bullet = Instantiate(bulletPrefab, bulletPos.transform.position, bulletPos.rotation * Quaternion.Euler(0, 0, 90));
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        if (bulletRb != null) {
            Vector2 shootDir = bulletPos.up;
            bulletRb.AddForce(shootDir * bulletForce, ForceMode2D.Impulse);
        }
        audioShoot.Play();
    }
    public float GetDamagePlayer() {
        return damagePlayer;
    }
    public void SetCoolDown(float cooldown) {
        cooldownShoot = cooldown;
        timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0) && !EventSystem.current.IsPointerOverGameObject()) {
            if (timer >= cooldownShoot) {
                Shoot();
                timer = 0;
            }
        }
    }

}
