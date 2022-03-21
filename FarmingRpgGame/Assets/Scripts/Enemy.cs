using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //amount of damage done to the player
    public int damage;
    public float speed;
    public float sightDistance;
    public GameObject playerObject;

    private void Update()
    {
        Vector2 sight = transform.position - playerObject.transform.position;
        if (sight.magnitude < sightDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerObject.transform.position, speed * Time.deltaTime);
        }
    }
}
