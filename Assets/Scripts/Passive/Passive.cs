using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Passive")]
public class Passive : ScriptableObject
{
    public GameObject passivePrefab;
    public string passiveName;
    public float R;
    public float G;
    public float B;
    [TextArea(15, 15)] public string description;
}
