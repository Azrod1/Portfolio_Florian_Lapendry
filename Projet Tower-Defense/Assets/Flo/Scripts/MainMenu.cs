using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject settingsWindow;

    public static MainMenu instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il n'y a plus d'instance 'MainMenu' dans la scène");
            return;
        }

        instance = this;
    }

    public void SettingsWindow()
    {
        settingsWindow.SetActive(true);

    }

    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }

    public void SelectLevel()
    {
        UIMain.instance.main.SetActive(false);
        settingsWindow.SetActive(false);
        UIMain.instance.selectLevel.SetActive(true);
    }

    public void BackToMainWhenSelectLevel()
    {
        UIMain.instance.selectLevel.SetActive(false);
        UIMain.instance.credits.SetActive(false);
        UIMain.instance.main.SetActive(true);
    }

    public void LoadSpecificLevel(int levelLoad)
    {
        AudioManager.instance.ChangeAudioWhenNewSceneLoad(levelLoad);
        SceneManager.LoadScene(levelLoad);
    }

    public void Credits()
    {
        UIMain.instance.credits.SetActive(true);
    }

    public void QuitButton()
    {
        // Fermer le jeu
        Application.Quit();
    }
}
