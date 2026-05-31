using UnityEngine;
using UnityEngine.AI;

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

    void Update()
    {
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
            animator.SetBool("IsMoving", agent.velocity.magnitude > 0.1f);

            agent.SetDestination(player.position);

            chaseTimer -= Time.deltaTime;

            if (dist < catchDistance)
            {
                animator.SetTrigger("Catch");
                chasing = false;
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

        animator.SetFloat(
            "Speed",
            agent.velocity.magnitude
        );
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
}
