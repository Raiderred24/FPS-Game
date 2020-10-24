using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{

    [SerializeField] Camera cameraController;
    [SerializeField] Transform rayOrigin;
    [SerializeField] float shootDistance = 10f;
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
        // Calculate direction of ray
        Vector3 rayDirection = cameraController.transform.forward;
        // Cast a debug ray
        Debug.DrawRay(rayOrigin.position, rayDirection * shootDistance, Color.yellow, 1f);
        // Do the raycast
        if(Physics.Raycast(rayOrigin.position, rayDirection, shootDistance))
        {
            //Code hits
            Debug.Log("Hit!");
        }
        else 
        {
            //Code misses
            Debug.Log("Miss");   
        }
    }
}
