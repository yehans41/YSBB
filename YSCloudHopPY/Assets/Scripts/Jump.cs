using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public bool canJump;
    public float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        jumpForce = 15;
    }

    // Update is called once per frame
    void Update()
    {
        if (rigidbody.velocity.y < -.01 || rigidbody.velocity.y > .01)
        {
            canJump = false;
        }
        else
        {
            canJump = true;
        }

        if (canJump && Input.GetButtonDown("Jump"))
        {
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}