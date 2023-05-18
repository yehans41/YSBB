using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float yForce;
    private RigidBody2D enemyRigidBody;

    void Start()
    {
        enemyRigidBody = GetComponent<RigidBody2D>();
    }
    private void FixedUpdate()
    {
        if (transform.position.x <= -8)
        {
           
        }
        if (transform.position.x >= 8)
        {
           
        }
     
    }
}
