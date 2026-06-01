using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset =
        new Vector3(6f, 8f, -6f);

    void LateUpdate()
    {
        if (target == null) return;

        transform.position =
            target.position + offset;

        transform.rotation =
            Quaternion.Euler(35f, -45f, 0f);
    }
}
