using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassiveButton : Hoverable
{
    public GameObject selectedImage;

    private void Start()
    {
        Passive passive = FindObjectOfType<GameSelection>().FindPassiveByName(elementName);
        description = passive.description;

        GetComponent<Button>().onClick.AddListener(Select);
    }

    void Select()
    {
        // Deactivate all other check marks
        var passiveButtons = FindObjectsOfType<PassiveButton>();
        foreach(var btn in passiveButtons)
        {
            btn.selectedImage.SetActive(false);
        }

        selectedImage.SetActive(true);
    }
}
