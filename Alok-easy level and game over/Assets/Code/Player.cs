using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed = 4;
    public int jumpForce = 500;
    public int bulletForce = 800;
    public LayerMask groundLayer;
    public Transform feet;
    public bool grounded = false;

    public GameObject bulletPrefab;
    Rigidbody2D _rigidbody;

    float xSpeed = 0;
    int jumps = 0;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        xSpeed = Input.GetAxis("Horizontal") * speed;
        _rigidbody.velocity = new Vector2(xSpeed, _rigidbody.velocity.y);

        
    }
    void Update()
    {
        grounded = Physics2D.OverlapCircle(feet.position, .3f, groundLayer);
        if(grounded){
            jumps = 1;
        }
        if(Input.GetButtonDown("Jump")&& (jumps > 0 || grounded))
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
            _rigidbody.AddForce(new Vector2(0,jumpForce));
            jumps--;
        }
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("balloon")){
            Destroy(other.gameObject);
        }
        if(other.CompareTag("Gate")){
            print("Load Next Scene Level");
        }
    }
}
