using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SoundMenuControl : MonoBehaviour
{
    bool isPlaying = true;
    [SerializeField] AudioSource audioSource;
    Button buttonComponent;
    public Sprite musicOff;
    public Sprite musicOn;

    void Start()
    {
        buttonComponent = GetComponent<Button>();
        buttonComponent.onClick.AddListener(PlayAndPause);
    }

    public void PlayAndPause()
    {
        if (isPlaying)
        {
            audioSource.Pause();
            GetComponent<Image>().sprite = musicOff;
            isPlaying = false;
        }
        else
        {
            audioSource.Play();
            GetComponent<Image>().sprite = musicOn;
            isPlaying = true;
        }
    }
}
    