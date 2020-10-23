using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private BoxCollider2D box2d;

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
       if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
       {
           float jumpSpeed = 8f; 
           rb2d.velocity = Vector3.up * jumpSpeed;
       }
    }
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(box2d.bounds.center, box2d.bounds.size, 0f, Vector3.down * .1f, platformLayerMask);
        Debug.Log(raycastHit2d.collider);
        return raycastHit2d.collider != null;
    }
}
