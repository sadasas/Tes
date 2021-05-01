using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public ScriptableHealt health;

    private void Update()
    {
        if (health.health <= 0)
        {
            Debug.Log("Enemy Dead");
            Destroy(gameObject);
        }
    }
}