using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadPlayer1ChoosingTank()
    {
        SceneManager.LoadScene("Player 1 Choosing Tank");
    }

    public void LoadPlayer2ChoosingTank()
    {
        SceneManager.LoadScene("Player 2 Choosing Tank");
    }

    public void LoadPlayer1ChoosingItems()
    {
        SceneManager.LoadScene("Player 1 Choosing Items");
    }

    public void LoadPlayer2ChoosingItems()
    {
        SceneManager.LoadScene("Player 2 Choosing Items");
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene("Main Game");
    }
}
