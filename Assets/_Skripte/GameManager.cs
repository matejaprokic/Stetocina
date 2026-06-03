using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TMP_Text crowText;
    public TMP_Text npcText;

    public GameObject losePanel;
    public GameObject winPanel;

    int crowHits = 0;
    int npcHits = 0;
    public int maxHits = 3;

    public NPCBehaviour npc;

    public AudioClip winSound;
    public AudioClip loseSound;

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

        if (crowHits >= maxHits)
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

        AudioManager.Instance.PlaySFX(loseSound);
    }

    void WinGame()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0f;

        AudioManager.Instance.PlaySFX(winSound);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }

    public void TaskCompleted(RevengeTask.TaskType type)
    {
        npcHits++;

        UpdateUI();

        npc.ReactToTask();

        if (npcHits >= maxHits)
        {
            WinGame();
        }
    }

 
}
