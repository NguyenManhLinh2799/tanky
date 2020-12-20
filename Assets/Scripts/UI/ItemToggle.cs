using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemToggle : Hoverable
{
    private void Start()
    {
        Item item = FindObjectOfType<GameSelection>().FindItemByName(elementName);
        description = item.description;
    }
}
