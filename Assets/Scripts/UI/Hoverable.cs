using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hoverable : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] protected string elementName;
    [SerializeField] protected Text infoText;

    protected string description;

    public void OnPointerEnter(PointerEventData eventData)
    {
        infoText.text = description;
    }
}
