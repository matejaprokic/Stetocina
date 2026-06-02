using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using StarterAssets;

public class NPCBehaviour : MonoBehaviour
{
    public Transform player;
    public Transform[] patrolPoints;

    public float visionDistance = 8f;
    public float catchDistance = 1.5f;
    public float chaseTime = 10f;

    public Animator animator;
    public NavMeshAgent agent;

    int patrolIndex;
    bool chasing;
    float chaseTimer;

    bool reactingToTask = false;

    private bool isAttacking = false;
    //bool attackInProgress = false;
    float attackCooldown = 0f;
    public float attackCooldownTime = 2f;

    int catches = 0;

    void Update()
    {
        if (reactingToTask)
        {
            agent.velocity = Vector3.zero;
            animator.SetFloat("Speed", 0f);
            return;
        }

        if (attackCooldown > 0)
            attackCooldown -= Time.deltaTime;

        float dist =
            Vector3.Distance(transform.position,
            player.position);

        // PLAYER SE VIDI
        if (dist < visionDistance)
        {
            chasing = true;
            chaseTimer = chaseTime;
        }

        // CHASE
        if (chasing)
        {
            animator.SetBool("IsChasing", true);

            animator.SetFloat(
                "Speed",
                agent.velocity.magnitude
            );

            agent.SetDestination(player.position);

            chaseTimer -= Time.deltaTime;

            if (dist < catchDistance && !isAttacking && attackCooldown <= 0f)
            {
                StartCoroutine(AttackRoutine());

                chasing = false;

                catches++;

                if (catches >= 3)
                {
                    // lose meni
                }

                return;
            }

            if (chaseTimer <= 0f)
            {
                chasing = false;
            }

            if (reactingToTask) return;

            return;
        }

        animator.SetBool("IsChasing", false);

        Patrol();

        if (!isAttacking)
        {
            animator.SetFloat("Speed", agent.velocity.magnitude);
        }
    
    }

    void Patrol()
    {
        if (patrolPoints.Length == 0) return;

        agent.SetDestination(
            patrolPoints[patrolIndex].position
        );

        if (Vector3.Distance(
            transform.position,
            patrolPoints[patrolIndex].position
            ) < 1f)
        {
            patrolIndex =
                (patrolIndex + 1)
                % patrolPoints.Length;
        }
    }

    public void ReactToTask()
    {
        StartCoroutine(DefeatedRoutine());
    }

    public void EndAttack()
    {
        isAttacking = false;
        agent.isStopped = false;
    }

    IEnumerator AttackRoutine()
    {
        isAttacking = true;
        //attackInProgress = true;

        agent.isStopped = true;

        animator.SetTrigger("Catch");

        // zakljucaj vranu
        StarterAssets.ThirdPersonController playerController = player.GetComponent<StarterAssets.ThirdPersonController>();

        if (playerController != null)
        {
            playerController.canMove = false;
        }

        // trajanje attack animacije
        yield return new WaitForSeconds(2.2f);

        // tek sad se racuna pogodak
        GameManager.Instance.CrowCaught();

        // otkljucaj vranu
        if (playerController != null)
        {
            playerController.canMove = true;
        }

        agent.isStopped = false;

        attackCooldown = attackCooldownTime;
        isAttacking = false;
        
    }

    IEnumerator DefeatedRoutine()
    {
        reactingToTask = true;

        chasing = false;

        agent.isStopped = true;
        agent.ResetPath();

        agent.velocity = Vector3.zero;

        animator.SetFloat("Speed", 0f);
        animator.SetBool("IsChasing", false);

        animator.SetTrigger("TaskDone");

        yield return new WaitForSeconds(6.7f);

        agent.velocity = Vector3.zero;

        agent.isStopped = false;

        reactingToTask = false;
    }
}
