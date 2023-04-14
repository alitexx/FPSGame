using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //CharacterController handels the collisions and movement
    public CharacterController controller;
    public float speed = 5f;

    public float gravity = -9.81f;

    public bool isGrounded;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private Vector3 velocity;

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
            //Setp 1 get current position
        Vector3 currentPos = transform.position;
        Vector3 motion = Vector3.zero;



        //Setp 2 get player position
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        //Step 3 set new position based on input and speed
        currentPos.x = currentPos.x + speed * inputX * Time.deltaTime;

        //Step 4 repeat for Z
        currentPos.z = currentPos.z + speed * inputY * Time.deltaTime;

        motion = (transform.forward * speed * inputY * Time.deltaTime) +
            (transform.right * speed * inputX * Time.deltaTime);

        //instead of moving it normally, we can use the Character controller for motion
        controller.Move(motion);
        velocity.y = gravity * Time.deltaTime;

    }
}
