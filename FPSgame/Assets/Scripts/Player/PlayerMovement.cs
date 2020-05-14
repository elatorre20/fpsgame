using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController Controls;

    //speed settings
    public float WalkSpeed = 12f;
    public float SprintSpeed = 24f;

    //gravity settings
    public float Gravity = -9.8f; //Must be negative
    public Transform GroundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask GroundMask;
    public bool IsGrounded;
    public float JumpHeight = 2f;

    Vector3 Velocity;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //physics check for ground
        IsGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        if(IsGrounded && Velocity.y < 0f) //resets gravity on landing
        {
            Velocity.y = -2f;
        }

        //get wasd input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 Move = transform.right * x + transform.forward * z;

        //walk or sprint as dictated by sprint key
        if (Input.GetButton("Sprint"))
        {
            Controls.Move(Move * SprintSpeed * Time.deltaTime);
        }
        else
        {
            Controls.Move(Move * WalkSpeed * Time.deltaTime);
        }
        
        //jump
        if (Input.GetButtonDown("Jump"))
        {
            Velocity.y = Mathf.Sqrt(JumpHeight * -2f * Gravity);
        }

        //gravity
        Velocity.y += Gravity * Time.deltaTime;
        Controls.Move(Velocity * Time.deltaTime);


    }
}
