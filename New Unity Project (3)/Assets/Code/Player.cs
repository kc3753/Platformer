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
    public static int balloonCount = 0;
    public bool manditem = false;
    public Text balloons;

    public GameObject bulletPrefab;
    Rigidbody2D _rigidbody;

    //animation
    Animator _animator;

    float xSpeed = 0;
    int jumps;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        xSpeed = Input.GetAxis("Horizontal") * speed;
        //animation
        _animator.SetFloat("Speed", Mathf.Abs(xSpeed));
        _rigidbody.velocity = new Vector2(xSpeed, _rigidbody.velocity.y);

        if((xSpeed < 0 && transform.localScale.x > 0) || (xSpeed > 0 && transform.localScale.x < 0))
        {
            transform.localScale *= new Vector2(-1,1);
        }

        balloons.text = balloonCount.ToString();
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
        if (Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene("GameStart");
        }
        if(NextLevel.levelToLoad == 2){
            if(feet.position.y <= -10){
                SceneManager.LoadScene("Level 2");
            }
        }
    }

    bool checkMand(){
        return manditem;
    }

    void OnTriggerEnter2D(Collider2D other) {
        print(other);
        if (other.CompareTag("Balloon")){
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
            balloonCount = balloonCount + 1;
        }
        
        if (other.CompareTag("Spike")){
            if(balloonCount > 0){
                balloonCount--;
            }
        }
        print(balloonCount);
    }

    void OnTriggerExit2D(Collider2D other){

        if (other.CompareTag("mandatory")){
            manditem = true;
            Destroy(other.gameObject);
        }
        print(balloonCount);
    }
}
