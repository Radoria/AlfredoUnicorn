using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private BoxCollider2D box2d;
    private bool IsGrounded;
    
    public float jumpSpeed = 8f;
    private float veloMovimento = 10f;
    public LayerMask platformLayerMask;

       // Start is called before the first frame update
    void Start()
    {
       rb2d = transform.GetComponent<Rigidbody2D>();
       box2d = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        
        Movement();
    }

    private void Movement()
    {
        //se o jogador cair das plataformas
        if (transform.position.y < -6.14f)
        {
            transform.position = new Vector3(-7.12f, -3.31f, 1.75f);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            rb2d.velocity = new Vector3(-veloMovimento, rb2d.velocity.y);
        }
        else
        {
            if (Input.GetKey(KeyCode.D))
        {
            rb2d.velocity = new Vector3(+veloMovimento, rb2d.velocity.y);
        }
        else 
        {
            //parado
            rb2d.velocity = new Vector3(0, rb2d.velocity.y);
        }
        
        }

    }
    void OnCollisionEnter2D(Collision2D col) 
    {
        if (col.gameObject.tag == "Ground")
        {
            IsGrounded = true;
        }
    }

    void Jump()
    {
        if (IsGrounded)
        {
            rb2d.velocity = Vector3.up * jumpSpeed;
            IsGrounded = false;
        }
    }

}
