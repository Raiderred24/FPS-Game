using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    // Enemy fires projectiles
    [SerializeField] GameObject levelController;
    int health = 100;
    public void TakeDamage(int damageToTake)
    {
        health -= damageToTake;
        Debug.Log(health + " health remaining");

        
        if (health <= 0)
        {
            levelController.GetComponent<Level01Controller>().IncreaseScore(100);
            Destroy(this.gameObject);
        }
    }
}
