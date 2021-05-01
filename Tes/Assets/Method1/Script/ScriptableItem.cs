using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = ("New Item"), menuName = ("Item"))]
public class ScriptableItem : ScriptableObject
{
    public string name;
    public float damage;
    public GameObject prefab;
}