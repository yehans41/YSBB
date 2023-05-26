using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToGoal : MonoBehaviour
{
    public Transform goal1;
    public Transform goal2;
    private Animator anim;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal1.position;
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("collectible"))
        {
            Destroy(other.gameObject);
            agent.destination = goal2.position;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (agent.hasPath)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }
}
