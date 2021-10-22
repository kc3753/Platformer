using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDownUp : MonoBehaviour
{
    float speed = .5f;
    float distance = 5;
    float startY;

    // Start is called before the first frame update
    void Start()
    {
        startY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition = transform.position;
        newPosition.y = Mathf.SmoothStep(startY, startY - distance, Mathf.PingPong(Time.time * speed, 1));
        transform.position = newPosition;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }
}
