using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource bgm;
    void Awake() {
        BGM();
    }
    void BGM() {
        int checkBMG = FindObjectsOfType<AudioSource>().Length;
        if (checkBMG > 1) { 
            Destroy(gameObject);
            return;
        }
        bgm.Play();
    }
    
}
