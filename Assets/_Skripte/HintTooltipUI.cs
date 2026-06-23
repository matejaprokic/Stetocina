using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HintTooltipUI : MonoBehaviour
{
    public static HintTooltipUI Instance;

    public GameObject tooltipPanel;
    public Image tooltipImage;

    public Transform player;

    public Vector3 worldOffset =
        new Vector3(0f, 2f, 0f);

    Coroutine currentRoutine;

    void Awake()
    {
        Instance = this;

        tooltipPanel.SetActive(false);
    }

    void Update()
    {
        if (!tooltipPanel.activeSelf)
            return;

        Vector3 screenPos =
            Camera.main.WorldToScreenPoint(
                player.position + worldOffset
            );

        tooltipPanel.transform.position =
            screenPos;
    }

    public void ShowHint(
        Sprite hintSprite,
        float duration = 1.5f
    )
    {
        Debug.Log(hintSprite);

        if (currentRoutine != null)
            StopCoroutine(currentRoutine);

        tooltipImage.sprite =
            hintSprite;

        tooltipPanel.SetActive(true);

        currentRoutine =
            StartCoroutine(
                HideAfter(duration)
            );
    }

    IEnumerator HideAfter(float time)
    {
        yield return new WaitForSecondsRealtime(time);

        tooltipPanel.SetActive(false);
    }
}