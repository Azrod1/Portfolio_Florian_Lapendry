using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class FinsihOut : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.instance.canEnd == true)
        {
            DontDestroyManager.instance.RemoveFromDontDestroyOnLoad();
            SceneManager.LoadScene(0);
        }
    }
}
