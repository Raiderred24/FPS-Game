﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{

    [SerializeField] Camera cameraController;
    [SerializeField] Transform rayOrigin;
    [SerializeField] float shootDistance = 10f;
    [SerializeField] GameObject visualFeedbackObject;
    [SerializeField] int weaponDamage = 50;
    [SerializeField] LayerMask hitLayers;
    [SerializeField] ParticleSystem feedbackParticles;
    [SerializeField] AudioSource Gunshot;

    RaycastHit objectHit; // Stores info on Raycast hit
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    // Fire the weapon using a Raycast
    void Shoot()
    {
        Gunshot.Play();
        // Calculate direction of ray
        Vector3 rayDirection = cameraController.transform.forward;
        // Cast a debug ray
        Debug.DrawRay(rayOrigin.position, rayDirection * shootDistance, Color.yellow, 1f);
        // Do the raycast
        if(Physics.Raycast(rayOrigin.position, rayDirection, out objectHit, shootDistance, hitLayers))
        {
            // Code hit object
            Debug.Log("You hit the " + objectHit.transform.gameObject.name);
            if (objectHit.transform.tag == "Enemy")
            {
                Debug.Log("Deal Damage");
                
                // Visual feedback
                //visualFeedbackObject.transform.position = objectHit.point;
                feedbackParticles.transform.position = objectHit.point;
                feedbackParticles.Emit(10);
                // Apply damage if target is an enemy
                EnemyShooter enemyShooter = objectHit.transform.gameObject.GetComponent<EnemyShooter>();
                if (enemyShooter != null)
                {
                    Debug.Log("enemy took damage");
                    enemyShooter.TakeDamage(weaponDamage);
                }
            }

        }
        else 
        {
            Debug.Log("You Missed");   
        }
    }
}
