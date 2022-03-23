using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyManager : MonoBehaviour
{
    public GameObject[] objects;
    public static DontDestroyManager instance;

    private void Awake() {
        if (instance != null) {
            Debug.LogWarning("Il n'y a plus d'instance 'DontDestroyManager' dans la scène");
            return;
        }

        instance = this;

        foreach (var element in objects) {
            DontDestroyOnLoad(element);
        }
    }

    public void RemoveFromDontDestroyOnLoad() {
        foreach (var element in objects) {
            SceneManager.MoveGameObjectToScene(element, SceneManager.GetActiveScene());
        }
    }
}
