using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private float moveSpeed = 7f;
    
    private void Update()
    {
        //Input Vector should be vector2 instead of vector3 because technically speaking there are 2 input keys on the keyboard and not 2
        Vector2 inputVector = new Vector2(0, 0);     
       
        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y += 1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y -= 1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x += 1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x -= 1f;
        }
        
        inputVector = inputVector.normalized;
        Vector3 moveVector = new Vector3(inputVector.x, 0, inputVector.y);
        
        
        transform.position += moveVector * (moveSpeed * Time.deltaTime);

        float rotationSpeed = 6f;
        
        //Slerp used for speherical smoothness and lerp used for position like smoothness
        transform.forward = Vector3.Slerp(transform.forward, moveVector,rotationSpeed * Time.deltaTime);

    }
}
