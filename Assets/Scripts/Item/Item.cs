using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject
{
    public GameObject itemPrefab;
    public string itemName;
    public Sprite icon;
    [TextArea(15, 15)] public string description;
}
