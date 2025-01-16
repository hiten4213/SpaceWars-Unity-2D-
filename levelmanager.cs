using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelmanager : MonoBehaviour
{
    score score;
    private void Awake()
     {
        score = FindObjectOfType<score>();
     }
 public void loadgame()
 {
    score.resetscore();
    SceneManager.LoadScene("game");
 }
 public void loadmenu()
 {
    SceneManager.LoadScene("menu");
 }
 public void loadgameover()
 {
    SceneManager.LoadScene("gameover");
 }
 public void quitgame()
 {
    Application.Quit();
 }

}
