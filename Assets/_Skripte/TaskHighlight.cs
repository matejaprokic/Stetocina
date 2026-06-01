using UnityEngine;

public class TaskHighlight : MonoBehaviour
{
    public Transform player;
    public GameObject highlightVisual;
    public float showDistance = 2f;

    void Update()
    {
        if (player == null || highlightVisual == null)
            return;

        float dist = Vector3.Distance(player.position, transform.position);

        bool shouldShow = dist <= showDistance;

        if (highlightVisual.activeSelf != shouldShow)
        {
            highlightVisual.SetActive(shouldShow);
        }
    }
}