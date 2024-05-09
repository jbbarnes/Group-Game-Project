using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullets : MonoBehaviour
{
    public float speed; // Speed of the projectile
    public bool goingDown; // Determines if the projectile is moving downwards

    // Update is called once per frame
    void Update()
    {
        // Move the projectile downwards if goingDown is true, otherwise move upwards
        transform.position += (goingDown ? Vector3.down : Vector3.up) * speed * Time.deltaTime;
    }

}
