using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Author [Barnes,Jordan]
 * Last Updated: [5/8/2024]
 * [This will take care of player movement and collision]
 */

public class PlayerScript : MonoBehaviour
{
    //use this to determine how fast the player moves
    public float speed;

    //lives for the player
    public int lives;

    //time player is stunned by laser
    public float stunTimer;

    public GameObject projectilePrefab; // Prefab of the projectile to be shot
    public Transform firePoint; // Point from which the projectile is shot
    public float fireRate = 1f; // Rate of fire in shots per second
    private float nextFireTime; // Time until the next shot can be fired

    void Update()
    {
        PlayerMove();

        PlayerShoot();
    }

    public void PlayerShoot()
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
        /// <summary>
        /// This will enable the player to move along the x axis using a and d keys
        /// </summary>
        private void PlayerMove()
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                //move the player in the left direction
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                //move the player in the right direction
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }

    IEnumerator Stun()
    {
        float currentPlayerSpeed = speed;
        speed = 0;
        yield return new WaitForSeconds(stunTimer);
        speed = currentPlayerSpeed;
    }

    void Shoot()
    {
        // Instantiate the projectile at the fire point position and rotation
        Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
    }

}
