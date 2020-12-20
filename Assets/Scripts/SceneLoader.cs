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

    public void LoadPlayer1ChoosingTank()
    {
        audioSource.Play();

        SceneManager.LoadScene("Player 1 Choosing Tank");
    }

    public void LoadPlayer2ChoosingTank()
    {
        audioSource.Play();
        SceneManager.LoadScene("Player 2 Choosing Tank");
    }

    public void LoadPlayer1ChoosingItems()
    {
        audioSource.Play();
        SceneManager.LoadScene("Player 1 Choosing Items");
    }

    public void LoadPlayer2ChoosingItems()
    {
        audioSource.Play();
        SceneManager.LoadScene("Player 2 Choosing Items");
    }

    public void LoadMainScene()
    {
        audioSource.Play();
        SceneManager.LoadScene("Main Game");
    }
}
