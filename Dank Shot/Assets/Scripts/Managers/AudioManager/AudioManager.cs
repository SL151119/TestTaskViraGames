using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    public static AudioManager Instance { get; private set; }

    [Header("Sounds for Mute/Unmute")]
    [SerializeField] private AudioSource[] audioHolder;

    [SerializeField] private AudioClip clickUISound;
    [SerializeField] private AudioClip changeLightSound;

    [Header("Sounds")]
    public AudioSource audioSource;
    public AudioClip _netSound;
    public AudioClip _starSound;
    public AudioClip _shootSound;
   
    private bool isSound;
        

    private void Awake()
    {
        Instance = this;
        LoadSoundsSettings();
    }

    public void PlayAudio(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }

    public void LightSound()
    {
        PlayAudio(changeLightSound);
    }
    public void ClickUISound()
    {
        PlayAudio(clickUISound);
    }

    public void EnableSound()
    {
        if (isSound)
        {
            foreach (var item in audioHolder)
            {
                item.enabled = false;
            }
            PlayerPrefs.SetInt("SoundOff", 1);
            isSound = false;
        }
        else
        {
            foreach (var item in audioHolder)
            {
                item.enabled = true;
            }
            PlayerPrefs.DeleteKey("SoundOff");
            isSound = true;
        }
    }

    private void LoadSoundsSettings()
    {
        isSound = PlayerPrefs.HasKey("SoundOff");
        if (isSound)
        {
            isSound = false;
            foreach (var item in audioHolder)
            {
                item.enabled = false;
            }
        }
        else
        {
            isSound = true;
            foreach (var item in audioHolder)
            {
                item.enabled = true;
            }
        }
    }
}
