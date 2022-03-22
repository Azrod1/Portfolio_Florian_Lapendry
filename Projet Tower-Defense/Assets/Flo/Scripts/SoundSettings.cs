using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundSettings : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider musicSlider;
    public Slider soundSlider;

    void Start()
    {
        audioMixer.GetFloat("Music", out float musicValueForSlider); // sortir la valeur du volume de la musique du jeu
        musicSlider.value = musicValueForSlider;

        audioMixer.GetFloat("SoundEffect", out float soundValueForSlider);
        soundSlider.value = soundValueForSlider;
    }

    public void SetMusicVolume()
    {
        audioMixer.SetFloat("Music", musicSlider.value);
    }

    public void SetSoundVolume()
    {
        audioMixer.SetFloat("SoundEffect", soundSlider.value);
    }
}
