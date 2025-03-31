using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 input_vec = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(input_vec);
    }

    public void CaptureMoveInput(InputAction.CallbackContext context)
    {
        input_vec = context.ReadValue<Vector2>(); 
    }
}
