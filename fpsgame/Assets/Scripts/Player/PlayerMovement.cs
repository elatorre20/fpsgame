using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //set camera transform
    [SerializeField] Transform Camera;

    //set speed values
    [SerializeField] float WalkSpeed;
    [SerializeField] float SprintSpeed;
    [SerializeField] float Sensitivity;

    CharacterController Controller;
    Transform Trans;
    Vector2 Move; //vector to store wasd input
    float FallVelocity;
    float g; //set gravity value
    float Vertical; //vertical camera angle
    bool Sprint;


    private void Awake()
    {
        Trans = transform;
        Controller = GetComponent<CharacterController>();
        g = Physics.gravity.y / 2f;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Move = context.ReadValue<Vector2>();
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        Sprint = (context.phase == InputActionPhase.Performed);
    }

    private void Update()
    {
        float deltaTime = Time.deltaTime;
        FallVelocity += g * deltaTime * deltaTime;
        float OldY = Trans.position.y;
        float speed = Sprint ? SprintSpeed : WalkSpeed;

        if(Move.y != 0)
        {
            Vertical = Vertical - Move.y * deltaTime * Sensitivity;
        }

    }

}
