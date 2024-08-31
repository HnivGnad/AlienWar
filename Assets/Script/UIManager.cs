using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] GameObject fill;
    [SerializeField] Slider shield;
    [SerializeField] Image colorHealth;
    HealthScript healthScript;
    ShieldScript shieldScript;
    
    void Start()
    {
        healthScript = FindObjectOfType<HealthScript>();
        shieldScript = FindObjectOfType<ShieldScript>();
        slider.maxValue = healthScript.GetHealthPlayer();
        shield.maxValue = shieldScript.GetHealthShield();
    }

    void Update()
    {
        HealthPlayer();
        HealthShield();
    }
    public void HealthPlayer() {
        slider.value = healthScript.GetHealthPlayer();
        if (slider.value <= 0) {
            fill.SetActive(false);
        }
        else {
            fill.SetActive(true);
        }

        if (slider.value <= 100f && slider.value > 60f) {
            colorHealth.color = Color.green;
        }
        if (slider.value <= 60f && slider.value > 30f) {
            colorHealth.color = Color.yellow;
        }
        if (slider.value <= 30f) {
            colorHealth.color = Color.red;
        }
        if (slider.value <= 0f) {
            healthScript.DestroyPlayer();
        }
    }
    public void HealthShield() {
        shield.value = shieldScript.GetHealthShield();
        if (shield.value <= 0) {
            shield.gameObject.SetActive(false);
        }
        else {
            shield.gameObject.SetActive(true);
        }
    }
    

}
