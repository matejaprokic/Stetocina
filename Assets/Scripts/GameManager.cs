using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TMP_Text crowText;
    public TMP_Text npcText;

    public GameObject losePanel;

    int crowHits = 0;
    int npcHits = 0;

    void Awake()
    {
        Instance = this;

        UpdateUI();

        losePanel.SetActive(false);
    }

    void UpdateUI()
    {
        crowText.text = "Vrana: " + crowHits + "/3";
        npcText.text = "Covek: " + npcHits + "/3";
    }

    public void CrowCaught()
    {
        crowHits++;

        UpdateUI();

        if (crowHits >= 3)
        {
            LoseGame();
        }
    }

    public void NPCHit()
    {
        npcHits++;

        UpdateUI();
    }

    void LoseGame()
    {
        losePanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}
