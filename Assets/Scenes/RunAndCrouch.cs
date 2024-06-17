using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    
    public float walkSpeed = 2.0f;
    public float runSpeed = 4.0f;
    public float crouchSpeed = 1.0f;

 
    public float standHeight = 2.0f;
    public float crouchHeight = 1.0f;

  
    private bool isGrounded;
    private bool isCrouched;

    private CharacterController characterController;
    private float originalHeight;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        originalHeight = characterController.height;
    }

    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Crouch();
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            TryStandUp();
        }
    }

    void Move()
    {
        float speed = walkSpeed;

        if (Input.GetKey(KeyCode.LeftShift) && !isCrouched)
        {
            speed = runSpeed;
        }
        else if (isCrouched)
        {
            speed = crouchSpeed;
        }

        float moveDirectionY = characterController.velocity.y;

        Vector3 move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        move = move.normalized * speed;
        move.y = moveDirectionY;

        characterController.Move(move * Time.deltaTime);
    }

    void Crouch()
    {
        characterController.height = crouchHeight;
        isCrouched = true;
    }

    void TryStandUp()
    {
        if (!CheckObstacleAbove())
        {
            characterController.height = standHeight;
            isCrouched = false;
        }
    }

    bool CheckObstacleAbove()
    {
        Ray ray = new Ray(transform.position, Vector3.up);
        float rayDistance = standHeight - crouchHeight;
        return Physics.Raycast(ray, rayDistance);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.normal.y > 0.5f)
        {
            isGrounded = true;
        }
    }
}

