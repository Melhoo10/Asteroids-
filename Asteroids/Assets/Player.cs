using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;

public class Player : MonoBehaviour
{
    //Player Input 
    private Vector2 input_vec = Vector2.zero;

    //Rotation 
    private float rotate_speed = 200f; //In degrees. 

    //componets
    private Rigidbody2D rb;

    //Moving 
    private float max_speed = 5.5f;

    private float acceleration = 13f;

    private Vector2 velocity = Vector2.zero;

    private float friction = 1f; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //If input player is holding down the A or D Key...
        if (input_vec.x != 0)
        {
            //Rotate the player
            rb.MoveRotation(rb.rotation + (-Mathf.Sign(input_vec.x) * rotate_speed * Time.fixedDeltaTime));

        }
        //if player is ho;dong down the w key 
        if (input_vec.y > 0)
        {
            

            //Add acceleration to our velocity.
            velocity += new Vector2(transform.up.x, transform.up.y) * acceleration * Time.fixedDeltaTime;

            //limit the velocity. 
            velocity = Vector2.ClampMagnitude(velocity, max_speed); 

            //Move the player. 
            rb.MovePosition(rb.position + (velocity * Time.fixedDeltaTime));

            

        }
        else //If the [layer is not pressing the W key... 
       
        //Move the player up. 
        rb.MovePosition(rb.position + (Vector2.up * Time.fixedDeltaTime));
    }
    
    public void CaptureMoveInput(InputAction.CallbackContext context)
    {
        input_vec = context.ReadValue<Vector2>(); 
    }
    
}
