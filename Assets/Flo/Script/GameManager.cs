using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool clefParent = false;
    public bool clefSDB = false;
    public bool clefEliot = false;
    public bool clefBureau = false;

    public int numberPage = 0;
    public bool canEnd = false;

    public static GameManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance'GameManager' dans la Scene");
            return;
        }

        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(1);
        }
    }
}
