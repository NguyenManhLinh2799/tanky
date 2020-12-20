using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Passive")]
public class Passive : ScriptableObject
{
    public GameObject passivePrefab;
    public string passiveName;
    [TextArea(15, 15)] public string description;
}
