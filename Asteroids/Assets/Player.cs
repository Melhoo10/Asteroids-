using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

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
        //Move the player up. 
        rb.MovePosition(rb.position + (Vector2.up * Time.fixedDeltaTime));
        }
         
    public void CaptureMoveInput(InputAction.CallbackContext context)
    {
        input_vec = context.ReadValue<Vector2>(); 
    }
    
}
