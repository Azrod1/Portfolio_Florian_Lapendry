using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoadScene : MonoBehaviour
{

    public GameObject[] objects;

    public static DontDestroyOnLoadScene instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il n'y a plus d'instance 'DontDestroyOnLoadScene' dans la sc�ne");
            return;
        }

        instance = this;

        foreach (var element in objects)
        {
            DontDestroyOnLoad(element);
        }
    }

    public void RemoveFromDontDestroyOnLoad()
    {
        foreach (var element in objects)
        {
            SceneManager.MoveGameObjectToScene(element, SceneManager.GetActiveScene());
        }
    }
}
