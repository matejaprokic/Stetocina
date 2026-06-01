using UnityEngine;

public class TaskBounce : MonoBehaviour
{
    public Transform player;

    public float showDistance = 2f;

    public float bounceHeight = 0.05f;
    public float bounceSpeed = 4f;

    Vector3 startPos;

    bool taskCompleted = false;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        if (player == null || taskCompleted)
        {
            transform.localPosition = startPos;
            return;
        }

        float dist =
            Vector3.Distance(
                player.position,
                transform.position
            );

        if (dist <= showDistance)
        {
            transform.localPosition =
                startPos +
                Vector3.up *
                Mathf.Sin(Time.time * bounceSpeed)
                * bounceHeight;
        }
        else
        {
            transform.localPosition = startPos;
        }
    }

    public void CompleteTask()
    {
        taskCompleted = true;

        transform.localPosition = startPos;
    }
}
