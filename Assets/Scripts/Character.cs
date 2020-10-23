using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private BoxCollider2D box2d;
    private bool IsGrounded;
    
    public float jumpSpeed = 8f;
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
