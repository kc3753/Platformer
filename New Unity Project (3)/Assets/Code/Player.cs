using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int speed = 4;
    public static int jumpForce = 500;
    public static int numjumps = 1;
    public int bulletForce = 800;
    public LayerMask groundLayer;
    public Transform feet;
    public bool grounded = false;
    public int balloonCount = 0;

    public GameObject bulletPrefab;
    Rigidbody2D _rigidbody;

    float xSpeed = 0;
    int jumps;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        xSpeed = Input.GetAxis("Horizontal") * speed;
        _rigidbody.velocity = new Vector2(xSpeed, _rigidbody.velocity.y);

        if((xSpeed < 0 && transform.localScale.x > 0) || (xSpeed > 0 && transform.localScale.x < 0))
        {
            transform.localScale *= new Vector2(-1,1);
        }
    }
    void Update()
    {
        grounded = Physics2D.OverlapCircle(feet.position, .3f, groundLayer);
        if(grounded){
            jumps = numjumps;
        }
        if(Input.GetButtonDown("Jump")&& (jumps > 0 || grounded))
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
            _rigidbody.AddForce(new Vector2(0,jumpForce));
            jumps--;
        }
        /*
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletForce,0));
        }
        */
        if (Input.GetKeyDown(KeyCode.K)){
            SceneManager.LoadScene("GameStart");
        }
        if(NextLevel.levelToLoad == 2){
            if(feet.position.y <= -10){
                SceneManager.LoadScene("Level 2");
            }
        }
    }
/*
    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Gate")){
            print("Move to next level.");
        }
    }
    */

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Balloon")){
            balloonCount++;
            Destroy(other.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.tag == "Balloon"){
            balloonCount++;
            Destroy(other.gameObject);
        }
    }
}
