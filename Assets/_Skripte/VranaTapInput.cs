using UnityEngine;
using UnityEngine.InputSystem;

public class VranaTapInput : MonoBehaviour
{
    Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        // PC klik
        if (Mouse.current != null &&
            Mouse.current.leftButton.wasPressedThisFrame)
        {
            HandleTap(Mouse.current.position.ReadValue());
        }

        // Telefon touch
        if (Touchscreen.current != null &&
            Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            HandleTap(
                Touchscreen.current.primaryTouch.position.ReadValue()
            );
        }
    }

    void HandleTap(Vector2 screenPos)
    {
        Ray ray = cam.ScreenPointToRay(screenPos);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            RevengeTask task =
                hit.collider.GetComponentInParent<RevengeTask>();

            if (task != null)
            {
                task.DoTask();
            }
        }
    }
}
