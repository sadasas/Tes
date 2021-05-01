using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = ("New Health "), menuName = ("Health"))]
public class ScriptableHealt : ScriptableObject
{
    public string name;
    public int health;

    public void AddDamage(int damage)
    {
        health -= damage;
    }
}