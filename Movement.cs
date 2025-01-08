using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private CharacterController controller;
    public Transform playerPos;
    public Transform cam;
    private Vector3 velocity;
    private float gravity = -9.8f;
    private float speed;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        playerPos = GetComponent<Transform>();
        controller = GetComponent<CharacterController>();
    }


    void Update()
    {
        Vector3 forwardDirection = cam.forward;
        Vector3 rightDirection = cam.right;
        forwardDirection.y = 0;
        rightDirection.y = 0;
        float forwardPos = Input.GetAxisRaw("Vertical");
        float rightPos = Input.GetAxisRaw("Horizontal");
        Vector3 moveDirection = (forwardDirection * forwardPos + rightDirection * rightPos);

        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = 10;
        }
        else
        {
            speed = 5;
        }

        if(moveDirection.magnitude != 0)
        {
            controller.Move(moveDirection * speed * Time.deltaTime);
        }

        

        if (controller.isGrounded && velocity.y <0f)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
