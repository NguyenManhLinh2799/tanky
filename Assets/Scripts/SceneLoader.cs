using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadChoosingTank()
    {
        SceneManager.LoadScene("Choosing Tank");
    }

    public void LoadChoosingItems()
    {
        SceneManager.LoadScene("Choosing Items");
    }
}
