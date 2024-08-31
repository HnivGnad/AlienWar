using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
    [SerializeField] int monney;
    ScoreManagerScript scoreManager;
    [SerializeField] AudioSource enemyDestroy;
    private void Start() {
        scoreManager = FindObjectOfType<ScoreManagerScript>();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            scoreManager.AddScore(monney);
            enemyDestroy.Play();
            Destroy(gameObject);
        }
    }
    public int GetMoney() {
        return monney;
    }
}
