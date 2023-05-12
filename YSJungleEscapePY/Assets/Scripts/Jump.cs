using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Jump : MonoBehaviour
{
    Rigidbody rigidbody;

    float jumpForce = 5.7f;
    float fallMultiplier = 1.5f; 

    public bool isGrounded;
    public float distToGround = 0.15f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        isGrounded = true;
    }

    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, distToGround);
        Debug.DrawRay(transform.position, Vector3.down * distToGround, Color.red);

        //jump movement
        if(Input.GetButtonDown("Jump") && isGrounded){
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        
        //increase gravity when falling
        if (rigidbody.velocity.y < 0){
            rigidbody.velocity += Physics.gravity * fallMultiplier * Time.deltaTime;
        }
    }
}
