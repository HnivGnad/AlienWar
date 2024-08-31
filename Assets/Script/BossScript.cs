using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BossScript : MonoBehaviour
{
    [SerializeField] float enemySpeed = 0.5f;
    [SerializeField] GameObject target;
    [SerializeField] int boundTakeDamage = 0;
    public float damageBoss = 200f;
    int countDamage;

    [SerializeField] float bossSpawn = 50f;
    float timeBoss = 0f;

    PolygonCollider2D polygonCollider;

    [SerializeField] AudioSource bossAudio;

    void Start()
    {
        countDamage = 0;
        polygonCollider = GetComponent<PolygonCollider2D>();
        polygonCollider.enabled = false;
    }

    void Update()
    {
        timeBoss += Time.deltaTime;
        if(timeBoss >= bossSpawn) {
            BossMove();
            polygonCollider.enabled = true;
            if (timeBoss - Time.deltaTime < bossSpawn) 
        {
                bossAudio.Play();
            }
        }
    }
    void BossMove() {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, enemySpeed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Shield") ||
           collision.gameObject.CompareTag("Player")) {
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Bullet")) {
            countDamage++;
            if(countDamage >= boundTakeDamage) {
                Destroy(gameObject);
                Debug.Log(countDamage);
            }
        }
    }
}
