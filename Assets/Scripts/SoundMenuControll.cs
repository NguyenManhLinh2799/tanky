using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundMenuControll : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject btn;
    bool Playing = true;
    static AudioSource audioSource;
    public Sprite onMusic;
    public Sprite offMusic;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAndPause()
    {
        if (Playing)
        {
            audioSource.Pause();
            btn.GetComponent<Image>().sprite = offMusic;
            Playing = false;
        }
        else
        {
            audioSource.Play();
            btn.GetComponent<Image>().sprite = onMusic;
            Playing = true;
        }
    }
}
    