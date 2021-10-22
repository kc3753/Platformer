using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class NextLevel : MonoBehaviour
{
    public Text notCollected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            int levelToLoad = SceneManager.GetActiveScene().name[6] - '0' + 1;

            if (!other.gameObject.GetComponent<Player>().manditem && levelToLoad == 3)
            {
                notCollected.text = "Hmm... I still need my shoes! Where are they...";
                StartCoroutine(Cleartext());
                return;
            }
            if (levelToLoad == 2)
            {
                PublicVars.jumpForce = 400;
                PublicVars.numJumps = 0;
            }
            else
            {
                PublicVars.jumpForce = 500;
                PublicVars.numJumps = 1;
            }
            // add the collected ballon in this level to the total ballon count 
            // only if the player passes this level
            PublicVars.balloonCount = other.gameObject.GetComponent<Player>().currBalloonCount;

            if (levelToLoad > 5)
            {
                SceneManager.LoadScene("GameOverScene");
            }
            else{
                SceneManager.LoadScene("Level " + levelToLoad.ToString());
            }
        }
    }

    IEnumerator Cleartext()
    {
        yield return new WaitForSeconds(3.5f);
        notCollected.text = " ";
    }
}