using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//**When creating obsticle course, make sure the platforms have the ground layer attached or else character movement will be impaired**

public class PlayerMovement : MonoBehaviour
{
    //VAR
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;


    [SerializeField] private bool isGround;

    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;

    [SerializeField] private float jumpHeight;

    [SerializeField] private float jumpWidthDistance;
    // [SerializeField] public float forwardForce = 10f;


    //need to add isfalling and isgrounded and redo some animations for the jump 
    private bool isJumping;
    private bool isGrounded;


    private Vector3 moveDirection;
    //keeps track of gravity
    private Vector3 velocity;
    //for gravity




    //REF 
    private CharacterController controller;
    private Animator anim;
    private Rigidbody rb;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
       rb = GetComponent<Rigidbody>();
    }

    //calls each frame
    private void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Slide();
        }
    }

    private void Move()
    {
        //tranform position = player position //
        isGround = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        //once player is grounded, stop the gravity
        if(isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //move fowards and back (Z axis)
        float moveZ = Input.GetAxis("Vertical");
        moveDirection = new Vector3(0, 0, moveZ);
        //our cursor does not determine the direction of movement
        moveDirection = transform.TransformDirection(moveDirection);

        if (isGround)
        {
            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {

                //walk 
                Walk();
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {

                //run
                Run();
            }
            else if (moveDirection == Vector3.zero)
            {
                Idle();

            }

            moveDirection *= moveSpeed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
               
                Jump();
                rb.AddForce(new Vector3(0, 1000, 0), ForceMode.Impulse);
                velocity.y += gravity * Time.deltaTime;

            }

        
        }
        

        //moveDirection *= walkSpeed;
        controller.Move(moveDirection * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Idle()
    {
        anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }

    private void Walk()
    {
        moveSpeed = walkSpeed;
        anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }

    private void Run()
    {
        moveSpeed = runSpeed;
        anim.SetFloat("Speed", 1, 0.1f,Time.deltaTime);
    }

    private void Jump()
    {
        // anim.SetBool("IsJumping", true);
        //isJumping = true;
       velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }

    private void Slide()
    {
       anim.SetTrigger("Slide");
    }
}
