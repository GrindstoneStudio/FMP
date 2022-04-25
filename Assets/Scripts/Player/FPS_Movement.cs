using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Movement : MonoBehaviour
{
    #region Variables
   
    public Vector3 moveDirection;
    public float walkSpeed;
    public float jumpForce;
    private Rigidbody rb;
    
    public bool grounded;
    public Transform groundCheck;
    public LayerMask groundLayer;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>(); 
    }
  

    // Update is called once per frame
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
    #region Walking
    // Walking Mechanic
    void Walking()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        moveDirection = (moveHorizontal * transform.right + moveVertical * transform.forward).normalized;
        Vector3 yVel = new Vector3(0, rb.velocity.y, 0);

        rb.velocity = moveDirection * (walkSpeed * 100) * Time.deltaTime;
        rb.velocity += yVel;
    }
    // jumping Mechanic
    void Jump()
    {
        rb.velocity = new Vector3( 0f, jumpForce, 0f);
    }

    #endregion
}
