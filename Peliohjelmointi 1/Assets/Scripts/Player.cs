using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Sami Kaski 26.1.2021
    public float jumpPower = 10.0f;
    Rigidbody2D myRigidbody;
    public bool isGrounded = false;
    void Start()
    {
        myRigidbody = transform.GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            myRigidbody.AddForce(Vector3.up * (jumpPower * myRigidbody.gravityScale * 20.0f));
        }
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
