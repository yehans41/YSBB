using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody rigidbody;
    float jumpForce = 5.7f;
    float fallMultiplier = 1.5f;
    public bool isGrounded;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, .15f);
        Debug.DrawRay(transform.position, Vector3.down * .15f, Color.red);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        if (rigidbody.velocity.y < 0)
        {
            rigidbody.velocity += Physics.gravity * fallMultiplier * Time.deltaTime;
        }
    }
}

