using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            Debug.Log("destroy");
            PlayerControl.instance.DestroyPelor();
        }
        else if (other.CompareTag("Enemy"))
        {
            PlayerControl.instance.AddDamage(other.gameObject);
            PlayerControl.instance.DestroyPelor();
        }
    }
}