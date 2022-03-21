using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5;
    Vector2 movement;
    
    void Update()
    {
        //Set Movement vector to values of X and Y player input
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
       
        //Set the speed by multiplying with the movement vector
        movement *= speed;
        
        //Move the player gameobject
        gameObject.transform.Translate(movement * Time.deltaTime); //We use Time.deltaTime here to sync movement with the framerate
        
        //Set Player Rotation
        gameObject.transform.eulerAngles = new Vector2(0, 0);
    }

    //When Player collides with another object
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //If the Object is an enemy
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            //reference the enemy
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            //damage the player
            PlayerStats.decrementHealth(enemy.damage);
        }
    }
}
