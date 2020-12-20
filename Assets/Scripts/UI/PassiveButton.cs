using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveButton : Hoverable
{
    private void Start()
    {
        Passive passive = FindObjectOfType<GameSelection>().FindPassiveByName(elementName);
        description = passive.description;
    }
}
