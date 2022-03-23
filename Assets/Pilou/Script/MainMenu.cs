using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsMenu;

    public void NewGame() {
        SceneManager.LoadScene(1);
    }

    public void OpenOption() {
        //gameObject.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void Quit() {
        Application.Quit();
    }
}
