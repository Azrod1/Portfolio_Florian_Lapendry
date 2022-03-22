using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public AudioClip[] playlistWinLost;

    public static PauseMenu instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il n'y a plus d'instance 'PauseMenu' dans la scène");
            return;
        }

        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.sceneCountInBuildSettings != 0)
        {
            if (!gameIsPaused)
            {
                Paused();
            }
            else
            {
                Resume();
            }
        }
    }

    void Paused()
    {
        UIPauseManager.instance.pauseMenu.SetActive(true);
        UILevelManager.instance.gameObject.SetActive(false);
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    public void Resume()
    {
        UIPauseManager.instance.pauseMenu.SetActive(false);
        MainMenu.instance.settingsWindow.SetActive(false);
        UILevelManager.instance.gameObject.SetActive(true);
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    public void ReplayButton()
    {
        // Recharge la scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        AudioManager.instance.ChangeAudioWhenNewSceneLoad(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        Resume();
        UIPauseManager.instance.victoryMenu.SetActive(false);
        UIPauseManager.instance.defeatMenu.SetActive(false);
        DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        SceneManager.LoadScene("MainMenu");
        AudioManager.instance.ChangeAudioWhenNewSceneLoad(0);
    }

    public void LoadLevel(int levelLoad)
    {
        MainMenu.instance.LoadSpecificLevel(levelLoad);    
    }

    public void GameLost()
    {
        UIPauseManager.instance.audioSourceWinLost.PlayOneShot(playlistWinLost[1]);
        UILevelManager.instance.gameObject.SetActive(false);
        UIPauseManager.instance.defeatMenu.SetActive(true);
    }

    public void GameWin()
    {
        //UIPauseManager.instance.audioSourceWinLost.PlayOneShot(playlistWinLost[0]);
        UILevelManager.instance.gameObject.SetActive(false);
        UIPauseManager.instance.victoryMenu.SetActive(true);
    }

    public void SettingsWindow()
    {
        MainMenu.instance.SettingsWindow();
    }
}
