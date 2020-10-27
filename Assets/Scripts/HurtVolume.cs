using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtVolume : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "FirstPersonPlayer")
        {
            other.GetComponent<PlayerMovement>().healthBar(1);
        }
    }
}