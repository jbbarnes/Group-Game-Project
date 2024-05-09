using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed; // Speed of movement
    public float boundaryX = 25f; // X-coordinate boundary

    private bool movingRight = true; // Initial movement direction

    void Update()
    {
        // Move the object left or right
        if (movingRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        // Check if the object reaches the boundaries
        if (transform.position.x >= boundaryX)
        {
            // Reverse direction if moving right and at the right boundary
            movingRight = false;
        }
        else if (transform.position.x <= -boundaryX)
        {
            // Reverse direction if moving left and at the left boundary
            movingRight = true;
        }
    }
}
