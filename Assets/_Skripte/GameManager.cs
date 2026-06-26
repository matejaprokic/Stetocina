using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TMP_Text crowText;
    public TMP_Text npcText;

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

    }

    void UpdateUI()
    {
        crowText.text = crowHits + "/3";
        npcText.text = npcHits + "/3";
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

        Time.timeScale = 0f;

        AudioManager.Instance.PlaySFX(loseSound);

        UIManager.Instance.ShowLosePanel();


    }

    void WinGame()
    {

        Time.timeScale = 0f;

        AudioManager.Instance.PlaySFX(winSound);

        UIManager.Instance.ShowWinPanel();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void TaskCompleted()
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
