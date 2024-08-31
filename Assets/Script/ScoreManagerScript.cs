using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagerScript : MonoBehaviour
{

    [SerializeField] public int score;
    [SerializeField] Text scoreText;
    void Start() {
        score = 0;
        UpdateScore();

    }
    void Update() {
        
    }
    public void AddScore(int points) {
        score += points;
        UpdateScore();
    }
    public void UpdateScore() {
        if (scoreText != null) { 
            scoreText.text = "$" + score.ToString();
        }
    }
    public int GetScore() {
        return score;
    }
    public void SubtractScore(int points) {
        score = Mathf.Max(score - points, 0);
    }
}
