using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //use this to determine how fast the player moves
    public float speed;

    //lives for the player
    public int lives;

    //time player is stunned by laser
    public float stunTimer;

    void Update()
    {
        PlayerMove();
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
  
}
