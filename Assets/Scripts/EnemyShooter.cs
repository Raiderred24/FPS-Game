using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    // Enemy fires projectiles

    int health = 100;
    public void TakeDamage(int damageToTake)
    {
        health -= damageToTake;
        Debug.Log(health + " health remaining");

        // Death check

    }
}
