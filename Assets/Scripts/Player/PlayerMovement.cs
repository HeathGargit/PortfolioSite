/*---------------------------------------------------------
File Name: PlayerMovement.cs
Purpose: This controls player movement
Author: Heath Parkes (heath@gargit.games)
Modified: 2019-07-23
-----------------------------------------------------------
Copyright 2019 HP
---------------------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    //RB for PHYSIX
    private Rigidbody2D m_RigidBody;

    //animation controller
    private Animator m_Animator;
    private SpriteRenderer m_SpriteRenderer;

    //Movement speed
    public float m_Speed = 10;
    public float m_JumpDistance = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        m_RigidBody = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //get inputs
        float xMovement = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(xMovement, 0.0f);
        float velocity = movement.magnitude * m_Speed; 

        bool shouldFlip = (m_SpriteRenderer.flipX ? (xMovement > 0.0f) : (xMovement < 0.0f));
        if(shouldFlip)
        {
            m_SpriteRenderer.flipX = !m_SpriteRenderer.flipX;
        }

        //set Animator
        m_Animator.SetFloat("xVelocity", velocity);



        //add force
        m_RigidBody.AddForce(movement * m_Speed);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            m_RigidBody.AddForce((Vector2.up * m_JumpDistance), ForceMode2D.Impulse);
        }
    }
}
