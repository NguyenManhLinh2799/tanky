using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEventHandler : MonoBehaviour
{
    [SerializeField] Button[] passiveButtons;
    [SerializeField] Button continueBtn;

    // Start is called before the first frame update
    void Start()
    {
        continueBtn.interactable = false;

        foreach(var btn in passiveButtons)
        {
            btn.onClick.AddListener(() => continueBtn.interactable = true);
        }
    }
}
