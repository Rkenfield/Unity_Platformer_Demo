﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    //public Rigidbody theRB;
    public float jumpForce;
    int jumpCount;
    public int maxJumps;
    public CharacterController controller;
    public float gravityScale;
    public float airMovement;


    private Vector2 moveDirection;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        maxJumps = 2;
    }

    // Update is called once per frame
    void Update()
    {
       
        

        if (controller.isGrounded)
        {
            jumpCount = 0;
            moveDirection = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y);
        }
        else
        {
            moveDirection = (new Vector2(Input.GetAxis("Horizontal") * moveSpeed * airMovement, moveDirection.y));
        }
        if (Input.GetButtonDown("Jump") && jumpCount < maxJumps)
        {
            moveDirection.y = jumpForce;
            jumpCount += 1;
            print(jumpCount);
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);
    }

  /*  void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Floor")
        {
            jumpCount = 0;
        }
    }
    */
}
