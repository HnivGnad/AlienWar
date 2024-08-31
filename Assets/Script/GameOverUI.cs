using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public void Restart() {
        SceneManager.LoadScene("MainGame");
    }
    public void MainMenu() {
        SceneManager.LoadScene("MenuGame");
    }
    
}
