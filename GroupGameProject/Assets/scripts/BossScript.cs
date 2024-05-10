using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    //lives for the player
    public int lives;

    //shooting mechanics
    public GameObject projectilePrefab; // Prefab of the projectile to be shot
    public Transform firePoint; // Point from which the projectile is shot
    public float fireRate = 0.5f; // Rate of fire in shots per second
    private float nextFireTime; // Time until the next shot can be fired

    void Update()
    {
        // Check if it's time to fire
        if (Time.time >= nextFireTime)
        {
            // Fire projectile
            Shoot();
            // Update the next fire time based on fire rate
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        // Instantiate the projectile at the fire point position and rotation
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        // You can add additional effects or logic here, like playing a shooting sound
    }

}
