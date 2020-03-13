﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public float health;
    public float speed;
    private float startSpeed;
    public GameObject player;
    //public vector2 distfromTarget; possibly add later
    public GameObject weapon; //enemies weapon, allows changing of weapons
    private Transform playerTransform;
    void Start()
    {
        playerTransform = player.GetComponent<Transform>();
        startSpeed = speed;
    }
        


    // Update is called once per frame
    void Update()
    {
        if (isDead())
        {
            Destroy(gameObject);
        }


    //moving towards player
    transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
        
    }

    void OnCollisionEnter(Collision other)
    {
       if(other.gameObject.tag == "Player")
        {
            Debug.Log("Player touched by enemy");
            speed = 0;
        }
    }

    void OnCollisionExit()
    {
        speed = startSpeed;
    }

    bool isDead()
    {
        if(this.health <= 0)
        {
            return true;
        }
        return false;
    }
}
