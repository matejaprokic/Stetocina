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

    private bool isAttacking = false;
    bool attackInProgress = false;
    float attackCooldown = 0f;
    public float attackCooldownTime = 2f;

    int catches = 0;

    void Update()
    {
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

    public void OnTaskCompleted()
    {
        animator.SetTrigger("TaskDone");
    }

    public void EndAttack()
    {
        isAttacking = false;
        agent.isStopped = false;
    }

    IEnumerator AttackRoutine()
    {
        isAttacking = true;
        attackInProgress = true;

        agent.isStopped = true;

        animator.SetTrigger("Catch");

        // zakljucaj vranu
        StarterAssets.ThirdPersonController playerController = player.GetComponent<StarterAssets.ThirdPersonController>();

        if (playerController != null)
        {
            playerController.canMove = false;
        }

        // trajanje attack animacije
        yield return new WaitForSeconds(1.2f);

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
}
