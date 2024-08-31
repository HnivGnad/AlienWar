using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour {
    [SerializeField] float gameDelay = 3f;
    [SerializeField] GameObject weaponPlayer;
    [SerializeField] float healthPlayer = 100f;
    float healthPlayerStart = 100f;
    Shooting shooting;
    Animator animator;
    

    [SerializeField] AudioSource audioDestroy;

    BossScript bossScript;

    void Start() {
        healthPlayer = healthPlayerStart;
        shooting = FindObjectOfType<Shooting>();
        animator = GetComponent<Animator>();
        bossScript = FindObjectOfType<BossScript>();
    }
    void Update() {
        QuitMainGame();
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            healthPlayer -= shooting.GetDamagePlayer();
            healthPlayer -= bossScript.damageBoss;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        healthPlayer -= shooting.GetDamagePlayer();
        if (collision.gameObject.CompareTag("BulletEnemy")) {
            Destroy(collision.gameObject);
        }
    }
    public float GetHealthPlayer() {
        return healthPlayer;
    }
    
    public void DestroyPlayer() {
        if (healthPlayer <= 0) {
            animator.SetTrigger("ExplodePlayer");
            weaponPlayer.SetActive(false);
            StartCoroutine(EndGame());
        }
    }
    IEnumerator EndGame() {
        audioDestroy.Play();

        yield return new WaitForSeconds(gameDelay);

        Destroy(gameObject);

        SceneManager.LoadScene("GameOver");

    }
    public void QuitMainGame() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("MenuGame");
        }
    }

}
