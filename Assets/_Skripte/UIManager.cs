using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject restartConfirmPanel;
    public GameObject settingsPanel;

    public GameObject mainPanel;
    public GameObject levelSelectPanel;
    public GameObject aboutPanel;

    public GameObject mobileControls;

    public GameObject winPanel;
    public GameObject losePanel;


    public static bool startGameDirectly = false;

    public static UIManager Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Debug.Log("UIManager object: " + gameObject.name);
        Debug.Log("mobileControls: " + mobileControls);

        if (startGameDirectly)
        {
            StartLevel1(); 
        }
        else
        {
            ShowMainMenu();
        }
    }

    void HideAllMenus()
    {
        mainPanel.SetActive(false);
        levelSelectPanel.SetActive(false);
        aboutPanel.SetActive(false);
        

        pausePanel.SetActive(false);
        restartConfirmPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }

    public void ShowMainMenu()
    {
        mobileControls.SetActive(false);

        Time.timeScale = 0f;

        HideAllMenus();
        mainPanel.SetActive(true);
    }

    public void OpenLevels()
    {
        mobileControls.SetActive(false);

        AudioManager.Instance.PlayUIClick();
        HideAllMenus();
        levelSelectPanel.SetActive(true);
    }

    public void OpenAbout()
    {
        Debug.Log("OPEN ABOUT");
        mobileControls.SetActive(false);

        HideAllMenus();
        aboutPanel.SetActive(true);
    }

    

    public void BackToMain()
    {
        mobileControls.SetActive(false);

        HideAllMenus();
        mainPanel.SetActive(true);
    }

    public void StartLevel1()
    {
        mobileControls.SetActive(true);

        startGameDirectly = true;

        

        Time.timeScale = 1f;

        HideAllMenus();

     
    }

    public void OpenGameSettings()
    {
        mobileControls.SetActive(false);

        settingsPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CloseGameSettings()
    {
        mobileControls.SetActive(true);

        settingsPanel.SetActive(false);
        Time.timeScale = 1f;
    }



    public void PauseGame()
    {
        mobileControls.SetActive(false);

        AudioManager.Instance.PlayUIClick();
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        mobileControls.SetActive(true);

        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void AskRestart()
    {
        mobileControls.SetActive(false);

        restartConfirmPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CancelRestart()
    {
        mobileControls.SetActive(true);

        restartConfirmPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        mobileControls.SetActive(true);

        startGameDirectly = true; 

        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMainMenu()
    {
        mobileControls.SetActive(false);

        startGameDirectly = false;

        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Time.timeScale = 1f;

        Application.Quit();

        Debug.Log("Exit Game");
    }

    public void ShowWinPanel()
    {
        mobileControls.SetActive(false);
        winPanel.SetActive(true);
    }

    public void ShowLosePanel()
    {
        mobileControls.SetActive(false);
        losePanel.SetActive(true);
    }
}