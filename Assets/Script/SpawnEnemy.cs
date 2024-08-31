using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {
    [SerializeField] GameObject[] enemyPrefab;
    [SerializeField] float rangeY;
    [SerializeField] float timeRate = 5f;
    [SerializeField] float decreaseRate = 0.1f;
    [SerializeField] float minSpawn = 1f;
    [SerializeField] GameObject bossPrefab;
    float currentTimeRate;
    float timer;
    
    

    HealthScript healthScript;
    void Start() {
        healthScript = FindObjectOfType<HealthScript>();
        currentTimeRate = timeRate;
    }

    void Update() {
        if (healthScript.GetHealthPlayer() <= 0) {
            return;
        }
        else {
            SpawnRate();
        }
    }
    void SpawnRate() {

        float ramdomY = Random.Range(-rangeY, rangeY);
        Vector3 posY = new Vector3(transform.position.x, ramdomY, 0);
        timer += Time.deltaTime;
        if (timer >= currentTimeRate) {
            int randomIndex = Random.Range(0, enemyPrefab.Length);
            Instantiate(enemyPrefab[randomIndex], posY, Quaternion.identity);
            timer = 0;

            currentTimeRate = Mathf.Max(minSpawn, currentTimeRate - decreaseRate);
        }

    }
}
