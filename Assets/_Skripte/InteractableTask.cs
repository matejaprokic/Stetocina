using UnityEngine;

public abstract class InteractableTask : MonoBehaviour, IInteractable
{
    public Transform player;
    public float interactDistance = 2f;

    bool done = false;

    public abstract bool CanComplete();

    public void Interact()
    {
        if (done) return;

        float dist = Vector3.Distance(transform.position, player.position);
        if (dist > interactDistance) return;

        if (!CanComplete()) return;

        CompleteTask();
    }

    protected virtual void CompleteTask()
    {
        done = true;

        TaskBounce bounce = GetComponent<TaskBounce>();
        if (bounce != null)
            bounce.CompleteTask();

        GameManager.Instance.TaskCompleted();
    }
}
