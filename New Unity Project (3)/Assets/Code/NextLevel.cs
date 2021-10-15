using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextLevel : MonoBehaviour
{
    public static int levelToLoad = 1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            levelToLoad ++;
            print(levelToLoad);
            if(levelToLoad == 2){
                SceneManager.LoadScene("Level 2");
                Player.jumpForce = 400;
                Player.numjumps = 0;
            }
            if(levelToLoad == 3){
                SceneManager.LoadScene("Level 3");
            }
            if(levelToLoad == 4){
                SceneManager.LoadScene("Level 4");
            }
            if(levelToLoad == 5){
                SceneManager.LoadScene("Level 5");
            }
        }
    }
}