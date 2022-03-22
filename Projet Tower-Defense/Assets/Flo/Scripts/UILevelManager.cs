using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILevelManager : MonoBehaviour
{
    public GameObject startButton;
    public Text baseHealth;
    public Text countMoney;
    public Text countWave;

    public static UILevelManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il n'y a plus d'instance 'UILevelManager' dans la scène");
            return;
        }

        instance = this;
    }
}
