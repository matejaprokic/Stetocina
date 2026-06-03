using UnityEngine;

public class UIButtonSound : MonoBehaviour
{
    public void PlayClick()
    {
        Debug.Log("UIButton clicked");

        if (AudioManager.Instance == null)
        {
            Debug.LogError("AudioManager.Instance is NULL");
            return;
        }

        AudioManager.Instance.PlayUIClick();
    }

    void Start()
    {
        Debug.Log("UIButtonSound START on " + gameObject.name);
    }
}