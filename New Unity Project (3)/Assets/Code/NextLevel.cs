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
            if (!other.gameObject.GetComponent<Player>().manditem)
            {
                notCollected.text = "Hmm... I still need my shoes! Where are they...";
                StartCoroutine(Cleartext());
                return;
            }
            PublicVars.levelToLoad++;
            print(PublicVars.levelToLoad);
            if (PublicVars.levelToLoad == 2)
            {
                PublicVars.jumpForce = 400;
                PublicVars.numJumps = 0;
            }
            else
            {
                PublicVars.jumpForce = 500;
                PublicVars.numJumps = 1;
            }
            PublicVars.balloonCount = other.gameObject.GetComponent<Player>().currBalloonCount;
            SceneManager.LoadScene("Level " + PublicVars.levelToLoad.ToString());
        }
    }

    IEnumerator Cleartext()
    {
        yield return new WaitForSeconds(3.5f);
        notCollected.text = " ";
    }
}