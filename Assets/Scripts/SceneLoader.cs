using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadChoosingMap()
    {
        StartCoroutine(PlayClickSoundThenLoad("Choosing Map"));
    }

    public void LoadTutorial()
    {
        StartCoroutine(PlayClickSoundThenLoad("Tutorial"));
    }
    public void LoadMainMenu()
    {
        FindObjectOfType<GameSelection>().ResetGame();
        StartCoroutine(PlayClickSoundThenLoad("Main Menu"));
    }
    public void LoadPlayer1ChoosingTank()
    {
        StartCoroutine(PlayClickSoundThenLoad("Player 1 Choosing Tank"));
    }

    public void LoadPlayer2ChoosingTank()
    {
        StartCoroutine(PlayClickSoundThenLoad("Player 2 Choosing Tank"));
    }

    public void LoadPlayer1ChoosingItems()
    {
        StartCoroutine(PlayClickSoundThenLoad("Player 1 Choosing Items"));
    }

    public void LoadPlayer2ChoosingItems()
    {
        StartCoroutine(PlayClickSoundThenLoad("Player 2 Choosing Items"));
    }

    public void LoadMainGame()
    {
        StartCoroutine(PlayClickSoundThenLoad("Main Game"));
    }

    IEnumerator PlayClickSoundThenLoad(string scene)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
        yield return new WaitForSeconds(0.5f);
        audioSource.Stop();
        SceneManager.LoadScene(scene);
    }
}
