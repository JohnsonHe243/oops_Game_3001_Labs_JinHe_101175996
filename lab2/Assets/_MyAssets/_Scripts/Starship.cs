using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarShip : AgentObject
{
    // Start is called before the first frame update
    [SerializeField] float movementSpeed = 1.0f;
    Rigidbody2D rb;


    new void Start() // Note the new!
    {
        base.Start(); // Explicitly invoking start of AgentObject
        Debug.Log("Starting Agent");

        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame

    void Update()
    {
       if (TargetPosition != null)
        {
            Seek();
        } 
    }

    private void Seek()
    {
        // Calculate desired velocity using kinematic see equation.
        Vector2 desiredVelocity = (TargetPosition - transform.position).normalized * movementSpeed;

        // Calculate the steering force.
        Vector2 steeringForce = desiredVelocity - rb.velocity;

        //Apply the steering force to the agent.
        rb.AddForce(steeringForce);
    }
}