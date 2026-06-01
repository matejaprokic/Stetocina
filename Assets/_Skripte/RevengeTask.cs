using UnityEngine;

public class RevengeTask : MonoBehaviour
{
    public enum TaskType
    {
        Eggs,
        Seeds,
        Scarecrow
    }

    public TaskType taskType;

    public Transform player;
    public float interactDistance = 2f;

    bool done = false;

    public void DoTask()
    {
        if (done) return;

        float dist =
            Vector3.Distance(
                transform.position,
                player.position
            );

        Debug.Log("Distance: " + dist);

        if (dist > interactDistance)
            return;

        done = true;

        GameManager.Instance.TaskCompleted(taskType);

        // optional: visual feedback
        Debug.Log(taskType + " completed!");
    }
}
