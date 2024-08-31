using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
    [SerializeField] float enemySpeed = 10f;
    [SerializeField] GameObject target;
    PolygonCollider2D polygon;
    Animator animator;
    bool destroy = false;

    HealthScript healthScript;

    [SerializeField] AudioSource audioEnemyDestroy;
    void Start() {
        animator = GetComponent<Animator>();
        polygon = GetComponent<PolygonCollider2D>();
        healthScript = FindObjectOfType<HealthScript>();
    }
    void Update() {
        Move();
    }
    public void Move() {
        if (destroy) {
            return;
        }
        if((healthScript.GetHealthPlayer() <= 0f)) {
            return;
        }
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, enemySpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Bullet")) {
            Explode();
            audioEnemyDestroy.Play();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Shield")) {
            Explode();

        }
        if (collision.gameObject.CompareTag("Player")) {
            Explode();
            healthScript.DestroyPlayer();
            audioEnemyDestroy.Play();
        }
    }
    public void Explode() {
        animator.SetTrigger("Explode");
        Destroy(gameObject, 0.5f);
        destroy = true;
        polygon.enabled = false;
    }
    public bool GetDestroy() {
        return destroy;
    }

}
