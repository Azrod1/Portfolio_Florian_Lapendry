using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public static bool gameIsPaused = false;
    public GameObject pauseMenu;
    public GameObject optionMenu;
    public GameObject dialogMenu;
    public GameObject pageMenu;
    public GameObject puzzleMenu;

    public static UIManager instance;

    public void Awake() {
        if (instance != null) {
            Debug.LogWarning("Il n'y a plus d'instance 'DontDestroyManager' dans la scène");
            return;
        }

        instance = this;
    }

    // Update is called once per frame
    void Update() {
        /*if (Input.GetKeyDown(KeyCode.Escape)) {
            if (gameIsPaused) {
                Resume();
            }
            else {
                Pause();
            }
        }*/

        if (Input.GetKeyDown(KeyCode.E)) {
            if (pageMenu.activeSelf) {
                ClosePage();
            }else if (dialogMenu.activeSelf) {
                CloseDialog();
            }else if (puzzleMenu.activeSelf) {
                ClosePuzzle();
            }
        }

    }

    public void Pause() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Options() {
        optionMenu.SetActive(true);
    }

    public void MainMenu() {
        SceneManager.LoadScene(0);
        DontDestroyManager.instance.RemoveFromDontDestroyOnLoad();
    }

    public void Quit() {
        Application.Quit();
    }

    public void OpenDialog() {
        dialogMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CloseDialog() {
        dialogMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OpenPage() {
        pageMenu.SetActive(true);
        Time.timeScale = 0f;
        GameManager.instance.numberPage++;
    }

    public void ClosePage() {
        pageMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OpenPuzzle() {
        puzzleMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ClosePuzzle() {
        puzzleMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
