using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    CharacterController cc;
    public float speed = 5;
    bool hitWall = false;
    Vector2 movement;

    void Start()
    {
        //cc = GetComponent<CharacterController>();
    }
    
    void Update()
    { 
        if (!hitWall)
        {
            movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            movement *= speed;
            gameObject.transform.Translate(movement * Time.deltaTime);
            //cc.Move(movement * Time.deltaTime);
        }
        else
        {
            movement = new Vector2(0, 0);
            cc.Move(movement * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Wall")
        {
            Debug.Log("Hit Wall");
            //hitWall = true;
        }
    }
}
