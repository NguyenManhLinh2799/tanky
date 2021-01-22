using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Map")]
public class Map : ScriptableObject
{
    public GameObject mapPrefab;
    public string mapName;
    [TextArea(15, 15)] public string description;
}
