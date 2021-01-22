using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapButton : Hoverable
{
    public GameObject selectedImage;

    private void Start()
    {
        var map = FindObjectOfType<GameSelection>().FindMapByName(elementName);
        description = map.description;

        GetComponent<Button>().onClick.AddListener(Select);
    }

    void Select()
    {
        // Deactivate all other check marks
        var mapButtons = FindObjectsOfType<MapButton>();
        foreach (var btn in mapButtons)
        {
            btn.selectedImage.SetActive(false);
        }

        selectedImage.SetActive(true);
    }
}
