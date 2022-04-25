using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TASK
//Broken code, fix it
//Mainly common problems you should have seen before

public class FPS_Movement_V2 : MonoBehaviour
{
    public float walkSpeed; //What's this for?
    public float jumpHeight; //What's this for?
    private float gravity = -9.81f; //What's this for?
    private CharacterController controller; //What's this for?
    private Vector3 velocity; //What's this for?
    private Vector3 moveDirection; //What's this for?
    public bool grounded;
    public Transform groundCheck;
    public LayerMask groundLayer;

    void Start()
    {
        controller = GetComponent<CharacterController>(); //What's this for?
    }

    void Update()
    {
        Walking();
        grounded = (Physics.Raycast(groundCheck.position, Vector3.down, 1f, groundLayer));
    {
        if(grounded)
        if(Input.GetKeyDown(KeyCode.Space))
    {
        Debug.Log("Jumped");
        Jump();
    }
    }
    }

    void Walking()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");//What's this for?
        float moveVertical = Input.GetAxisRaw("Vertical");//What's this for?
        moveDirection = (moveHorizontal * transform.right + moveVertical * transform.forward);//What's this for?
        controller.Move(moveDirection * walkSpeed * Time.deltaTime);//What's this for?  
        velocity.y += gravity * Time.deltaTime; //What's this for?
        controller.Move(velocity * Time.deltaTime); //What's this for?
    }

    void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); //What's this for?
    }
}
