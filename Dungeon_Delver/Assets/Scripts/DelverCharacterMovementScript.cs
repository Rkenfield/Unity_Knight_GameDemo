using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class DelverCharacterMovementScript: MonoBehaviour
{

    public CharacterController controller;

    public Transform cam;

    public float speed = 3;

    public float turnSmoothTime = 0.1f;

    float turnSmoothVelocity;

    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frames
    void Update()
    {
        MveHandler(); 
    }

    private void MveHandler()
    {
        //This Handles movement of the player
        
        //Sets up variables for inputs from user to move
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        //The thing that handles movement, normalized makes it so moving diagonal doesn't increase speed
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        //Checks for if their is movement from the player
        if (direction.magnitude >= 0.1f)
        {
            //handles rotation of character based on the camera
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            //makes the rotation smoother and not snapped
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

        }

        animator.SetFloat("MovementSpeed", 0.5f * speed * direction.magnitude, turnSmoothTime, Time.deltaTime);
    }

    
}
