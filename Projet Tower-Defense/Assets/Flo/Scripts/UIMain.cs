using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMain : MonoBehaviour
{
    public GameObject main;
    public GameObject selectLevel;
    public GameObject credits;

    public static UIMain instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il n'y a plus d'instance 'UIMain' dans la scène");
            return;
        }

        instance = this;
    }
}
