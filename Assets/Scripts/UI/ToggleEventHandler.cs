using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleEventHandler : MonoBehaviour
{
    [SerializeField] Toggle[] itemToggles;
    [SerializeField] int maxItems = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Limit3Items();
    }

    private void Limit3Items()
    {
        int count = 0;
        foreach (Toggle toggle in itemToggles)
        {
            if (toggle.isOn)
            {
                count++;
            }
        }

        if (count >= maxItems)
        {
            foreach (Toggle toggle in itemToggles)
            {
                if (!toggle.isOn)
                {
                    toggle.interactable = false;
                }
            }
        }
        else
        {
            foreach (Toggle toggle in itemToggles)
            {
                toggle.interactable = true;
            }
        }
    }
}
