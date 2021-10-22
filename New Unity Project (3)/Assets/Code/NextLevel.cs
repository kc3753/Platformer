using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class NextLevel : MonoBehaviour
{
    public Text notCollected;

    void Start()
    {
        InvokeRepeating("cleartext", 0f, 3.5f);
    }
    private void cleartext()
    {
        if (notCollected.text != " ")
        {
            notCollected.text = " ";
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.gameObject.GetComponent<Player>().manditem == true)
            {
                print("yay");
            }
            else
            {
                notCollected.text = "Hmm... I still need my shoes! Where are they...";
            }
            PublicVars.levelToLoad++;
            print(PublicVars.levelToLoad);
            if (PublicVars.levelToLoad == 2)
            {
                PublicVars.jumpForce = 400;
                PublicVars.numJumps = 0;
            }
            SceneManager.LoadScene("Level " + PublicVars.levelToLoad.ToString());
        }
    }
}