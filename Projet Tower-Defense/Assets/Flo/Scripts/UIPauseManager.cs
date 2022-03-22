using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPauseManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject victoryMenu;
    public GameObject defeatMenu;
    public AudioSource audioSourceWinLost;

    public static UIPauseManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il n'y a plus d'instance 'UIPauseManager' dans la scène");
            return;
        }

        instance = this;
    }
}
