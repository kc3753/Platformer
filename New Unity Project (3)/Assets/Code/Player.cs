using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int speed = 4;
    public LayerMask groundLayer;
    public Transform feet;
    public bool grounded = false;
    public bool manditem = false;
    public Text balloons;

    // public GameObject bulletPrefab;
    Rigidbody2D _rigidbody;

    //animation
    Animator _animator;

    float xSpeed = 0;
    int jumps = 0;
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

        if ((xSpeed < 0 && transform.localScale.x > 0) || (xSpeed > 0 && transform.localScale.x < 0))
        {
            transform.localScale *= new Vector2(-1, 1);
        }
    }
    void Update()
    {
        grounded = Physics2D.OverlapCircle(feet.position, .3f, groundLayer);
        if (grounded)
        {
            jumps = PublicVars.numJumps;
        }
        if (Input.GetButtonDown("Jump") && (jumps > 0 || grounded))
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
            _rigidbody.AddForce(new Vector2(0, PublicVars.jumpForce));
            jumps--;
        }
        /*
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletForce,0));
        }
        */
        /*
        if (Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene("GameStart");
        }
        */

        if (feet.position.y <= -10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    bool checkMand()
    {
        return manditem;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        print(other);
        if (other.CompareTag("Balloon"))
        {
            PublicVars.balloonCount++;
            Destroy(other.gameObject);
        }

        else if (other.CompareTag("Spike"))
        {
            if (PublicVars.balloonCount > 0)
            {
                PublicVars.balloonCount--;
            }
        }
        else if (other.CompareTag("mandatory"))
        {
            manditem = true;
            Destroy(other.gameObject);
        }
        print(PublicVars.balloonCount);
        balloons.text = PublicVars.balloonCount.ToString();
    }
}
