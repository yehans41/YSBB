using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControls : MonoBehaviour
{
    public float speed = 2;
    public float attackingDistance = 1;
    public Vector3 direction;
    private Animator anim;
    private Rigidbody rb;
    private Transform target;
    public bool isFollowingTarget;
    public bool isAttackingTarget;
    private float chasingPlayer = 0.01f;
    public float currentAttackingTime;
    public float maxAttackingTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        isFollowingTarget = true;
        currentAttackingTime = maxAttackingTime;
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void FollowTarget()
    {
        if (!isFollowingTarget)
        {
            return;
        }

        if (Vector3.Distance(transform.position, target.position) >= attackingDistance)
        {
            direction = target.position - transform.position;
            direction.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 100);
            if(rb.velocity.sqrMagnitude != 0)
            {
                rb.velocity = transform.forward * speed;
                anim.SetBool("Walk", true);
            }
        }
        else if (Vector3.Distance(transform.position, target.position) <= attackingDistance)
        {
            rb.velocity = Vector3.zero;
            anim.SetBool("Walk", false);
            isFollowingTarget = false;
            isAttackingTarget = true;
        }
    }
    void Attack()
    {
        if (!isAttackingTarget)
        {
            return;
        }
        currentAttackingTime += Time.deltaTime;

        if(currentAttackingTime > maxAttackingTime)
        {
            EnemyAttack(Random.Range(1, 4));
            currentAttackingTime = 0f;
        }
    }
    private void EnemyAttack(int attack)
    {
        if (attack == 1)
        {
            anim.SetTrigger("Attack1");
        }
        if (attack == 2)
        {
            anim.SetTrigger("Attack2");
        }
        if (attack == 3)
        {
            anim.SetTrigger("Attack3");
        }
    }
    private void FixedUpdate()
    {
        FollowTarget();
    }
    // Update is called once per frame
    void Update()
    {
        Attack();
    }
}
