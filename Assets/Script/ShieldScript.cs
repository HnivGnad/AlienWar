using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShieldScript : MonoBehaviour {
    [SerializeField] float healthShield;
    [SerializeField] float damageShieldTaken = 35f;
    [SerializeField] GameObject shield;
    [SerializeField] AudioSource shieldHitAudio;
    void Start() {
        
    }
    private void Update() {

    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Enemy")) {

            healthShield -= damageShieldTaken;
            shieldHitAudio.Play();
            if (healthShield <= 0) {
                shield.SetActive(false);
            }
            if (healthShield > 0) {
                shield.SetActive(true);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("BulletEnemy")) {

            healthShield -= damageShieldTaken;
            if (healthShield <= 0) {
                shield.SetActive(false);
            }
            if (healthShield > 0) {
                shield.SetActive(true);
            }
            Destroy(collision.gameObject);
        }
    }
    public float GetHealthShield() {
        return healthShield;
    }
    public void ShieldRepair() {
        shield.gameObject.SetActive(true);
        healthShield = 200f;
    }
}