using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject pauseMenu;
    
    public static bool paused = false;
    private void Start(){
        Resume();
    }
    private void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(paused){
                Resume();
            }
            else{ 
                pauseMenu.SetActive(true);
                paused = true;
                Time.timeScale = 0;
            } 
        }
    }
    public void Resume(){
        pauseMenu.SetActive(false);
        paused = false;
        Time.timeScale = 1;
    }
    
    
    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void Quit(){
        SceneManager.LoadScene("GameStart");
    }
}


