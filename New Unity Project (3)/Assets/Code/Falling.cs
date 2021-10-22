using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    bool isFalling = false;
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isFalling)
        {
            isFalling = true;
            StartCoroutine(Fall());
        }
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(.5f);
        GetComponent<Rigidbody2D>().isKinematic = false;
    }
}
