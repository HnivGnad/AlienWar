using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {
    [SerializeField] GameObject target;
    [SerializeField] Transform posBullet;

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float forceBullet;

    [SerializeField] float spawnRate = 1f;
    [SerializeField] float damageEnemy;
    float timer;
    HealthScript healthScript;
    EnemyMove enemyMove;

    [SerializeField] AudioSource audioShoot;
    void Start() {
        healthScript = FindObjectOfType<HealthScript>();
        enemyMove = FindObjectOfType<EnemyMove>();
    }

    void Update() {
        Rotation();
        timer += Time.deltaTime;
        if (timer > spawnRate) {
            if (enemyMove.GetDestroy()) {
                return;
            }
            Shoot();
            timer = 0;
        }
    }

    void Rotation() {
        Vector2 shootDir = target.transform.position - posBullet.transform.position;
        float angle = Mathf.Atan2(shootDir.y, shootDir.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0, 0, angle - 180);
        transform.rotation = rotation;
    }
    void Shoot() {
        GameObject bullet = Instantiate(bulletPrefab, posBullet.position, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        Vector2 shootDir = (target.transform.position - posBullet.transform.position).normalized;
        bulletRb.AddForce(shootDir * forceBullet, ForceMode2D.Impulse);

        audioShoot.Play();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            Destroy(gameObject);
            healthScript.DestroyPlayer();
        }
    }
}
