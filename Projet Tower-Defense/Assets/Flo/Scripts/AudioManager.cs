using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il n'y a plus d'instance 'AudioManager' dans la scène");
            return;
        }

        instance = this;
    }

    void Start()
    {
        audioSource.clip = playlist[0];
        audioSource.Play();
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void ChangeAudioWhenNewSceneLoad(int scene)
    {
        audioSource.clip = playlist[scene];
        audioSource.Play();
    }
}
