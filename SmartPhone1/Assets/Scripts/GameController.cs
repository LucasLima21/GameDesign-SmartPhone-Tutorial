using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Text timerDisplay;
    public float timer;
    private bool asLost;

    private int sentinel = 0;
    void Update(){ 
        if(asLost == false){
            timerDisplay.text = timer.ToString("F0");
        }

        if(timer <= 0){
            sentinel++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            if(sentinel == 5){
                gameOverPanel.SetActive(true); //quando finaliza a fase 5 é o fim
            }
        }
        else{
            timer -= Time.deltaTime;
        }
    }
    
    /*
    void Delay(){
        gameOverPanel.SetActive(true);
    }*/
    public void ShowGameOver(){
        asLost = true;
        gameOverPanel.SetActive(true);
        
    }
    public void GoToScene(){
        SceneManager.LoadScene("Level_1");
    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }


}
