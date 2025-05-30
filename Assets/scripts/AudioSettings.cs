using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class AudioSettings : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider volumeSlider;
    
    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volume");
    }

    public void AudioVol(float volume)
    {
        mixer.SetFloat("vol", volume);
        PlayerPrefs.SetFloat("volume",volumeSlider.value);
    }
}
