using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject restartConfirmPanel;
    public GameObject gameSettingsPanel;

    public GameObject mainPanel;
    public GameObject levelSelectPanel;
    public GameObject aboutPanel;
    public GameObject mainSettingsPanel;

    public static bool startGameDirectly = false;

    void Start()
    {
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
        mainSettingsPanel.SetActive(false);

        pausePanel.SetActive(false);
        restartConfirmPanel.SetActive(false);
        gameSettingsPanel.SetActive(false);
    }

    public void ShowMainMenu()
    {
        Time.timeScale = 0f;

        HideAllMenus();
        mainPanel.SetActive(true);
    }

    public void OpenLevels()
    {
        HideAllMenus();
        levelSelectPanel.SetActive(true);
    }

    public void OpenAbout()
    {
        HideAllMenus();
        aboutPanel.SetActive(true);
    }

    public void OpenMainSettings()
    {
        HideAllMenus();
        mainSettingsPanel.SetActive(true);
    }

    public void BackToMain()
    {
        HideAllMenus();
        mainPanel.SetActive(true);
    }

    public void StartLevel1()
    {
        startGameDirectly = true;

        Time.timeScale = 1f;

        HideAllMenus();

     
    }

    public void OpenGameSettings()
    {
        gameSettingsPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CloseGameSettings()
    {
        gameSettingsPanel.SetActive(false);
        Time.timeScale = 1f;
    }



    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void AskRestart()
    {
        restartConfirmPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CancelRestart()
    {
        restartConfirmPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        startGameDirectly = true; 

        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMainMenu()
    {
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
}