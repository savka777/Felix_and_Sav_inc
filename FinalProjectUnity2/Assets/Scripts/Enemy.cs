using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;
    GameObject player;
    CharacterController character;


    //Jumping code
    bool isJumpPressed = false;
    float initialJumpVelocity;
    float maxJumpHeight = 4.0f;
    float maxJumpTime = 0.75f;
    [SerializeField] float jumpDistance = 1.0f;
    bool isJumping = false;
    float gravity = -9.8f;
    //gravity code
    /*
[SerializeField] private bool isGround;
[SerializeField] private float groundCheckDistance;
[SerializeField] private LayerMask groundMask;
private Vector3 velocity;
[SerializeField] private float gravity;*/
    void Start()
    {
        player = GameObject.Find("C02");
        animator = GetComponent<Animator>();
        animator.SetBool("IsWalking", true);
        character = GetComponent<CharacterController>();
        setUpJumpVariables();
    }

// Update is called once per frame
    void Update()
    {
       
        Vector3 direction = (player.transform.position) - (gameObject.transform.position);
        direction.Normalize();
        //transform.position += direction *3* Time.deltaTime;
        character.Move(direction* Time.deltaTime*3);
        Vector3 minDirection = new  Vector3(0, direction.y, 0);
        transform.rotation = Quaternion.LookRotation(direction-(minDirection));




    //gravity code
    /*
    isGround = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

    //once player is grounded, stop the gravity
    if (isGround && velocity.y < 0)
    {
        velocity.y = -2f;
    }
    velocity.y += gravity * Time.deltaTime;*/
    }
    void setUpJumpVariables()
    {
        float timeToApex = maxJumpTime / 2;
        gravity = (-2 * maxJumpHeight) / Mathf.Pow(timeToApex, 2);
        initialJumpVelocity = (2 * maxJumpHeight) / timeToApex;
    }
    void handleJump()
    {


        if (!isJumping && character.isGrounded && isJumpPressed)
        {
            animator.SetBool("isJumping", true);
            isJumping = true;
            //direction.y = initialJumpVelocity * jumpDistance; ;
            //direction.y = initialJumpVelocity * jumpDistance;
        }
        else if (!isJumpPressed && isJumping && character.isGrounded)
        {
            isJumping = false;
        }
    }
}
