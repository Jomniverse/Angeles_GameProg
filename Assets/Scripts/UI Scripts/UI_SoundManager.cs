using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UI_SoundManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

   
public void SetMasterVolume(float level)
    {
       audioMixer.SetFloat("MainVolume", Mathf.Log10(level)*20f);
    }

public void SetMusicVolume(float level)
    {
        audioMixer.SetFloat("MusicVolume",Mathf.Log10(level)*20f);
    }

public void SetSFXVolume(float level)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(level)*20f);
    }
}
