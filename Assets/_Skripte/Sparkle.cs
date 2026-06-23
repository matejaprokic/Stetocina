using UnityEngine;

public class Sparkle : MonoBehaviour
{
    public Transform player;

    public float showDistance = 3f;

    public float floatHeight = 0.05f;
    public float floatSpeed = 2f;

    public float scaleAmount = 0.15f;
    public float scaleSpeed = 3f;

    Vector3 startPos;
    Vector3 startScale;

    SpriteRenderer sr;

    void Start()
    {
        startPos = transform.localPosition;
        startScale = transform.localScale;

        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float dist =
            Vector3.Distance(
                player.position,
                transform.parent.position
            );

        sr.enabled = dist <= showDistance;

        if (!sr.enabled)
            return;

        transform.localPosition =
            startPos +
            Vector3.up *
            Mathf.Sin(Time.time * floatSpeed)
            * floatHeight;

        float pulse =
            1 +
            Mathf.Sin(Time.time * scaleSpeed)
            * scaleAmount;

        transform.localScale =
            startScale * pulse;
    }

    void LateUpdate()
    {
        transform.forward =
            Camera.main.transform.forward;
    }
}