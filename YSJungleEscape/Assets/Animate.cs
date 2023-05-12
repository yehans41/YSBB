using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    Animator Animator;
    // adding our Jump script
    Jump Jump;
    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
        // adding the jump script to the jump variable
        Jump = GetComponent<Jump>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Jump.isGrounded)
        {
            //not touching the ground,
            //therefore msut be in the air, so will play the jump animation
            Animator.SetBool("isJumping", true);
            Animator.SetBool("isWalking", false);
            Animator.SetBool("isWalkingBackwards", false);
            Animator.SetBool("isIdle", false);
        }
        if (Jump.isGrounded)
        {
            // will run if no if is ran play idle animation
            Animator.SetBool("isJumping", false);
            Animator.SetBool("isWalking", false);
            Animator.SetBool("isWalkingBackwards", false);
            Animator.SetBool("isIdle", true);
            if (Input.GetAxisRaw("Vertical") == 1)
            {
                // play walking animation
                Animator.SetBool("isWalking", true);
                Animator.SetBool("isWalkingBackwards", false);
                Animator.SetBool("isIdle", false);
            }
            if (Input.GetAxisRaw("Vertical") == -1)
            {
                //playing walking backwards animation
                Animator.SetBool("isWalking", false);
                Animator.SetBool("isWalkingBackwards", true);
                Animator.SetBool("isIdle", false);
            }
        }
    }
}