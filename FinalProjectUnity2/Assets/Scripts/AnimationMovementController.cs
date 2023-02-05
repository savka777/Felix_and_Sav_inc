using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationMovementController : MonoBehaviour
{
    PlayerInput playerInput;
    CharacterController characterController;
    Animator animator;

    int isWalkingHash;
    int isRunningHash;

    Vector2 currentMovementInput;
    Vector3 currentMovement;
    Vector3 currentRunMovement;
    bool isMovementPressed;
    bool isRunPressed;

    [SerializeField] float runMultipler;
    [SerializeField] float walkMultipler;

    [SerializeField] float rotationFactorPerFrame = 1.0f;



    //jumping 
    //(PARABOLA) (CDC BUILDING A BETTER JUMP KYLE PITTMAN) 
    bool isJumpPressed = false;
    float initialJumpVelocity;
    float maxJumpHeight = 4.0f;
    float maxJumpTime = 0.75f;
    [SerializeField] float jumpDistance = 1.0f;
    bool isJumping = false;
    
    float groundedGravity = -.05f;
    float gravity = -9.8f;


    void Awake()
    {
        playerInput = new PlayerInput();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        isWalkingHash = Animator.StringToHash("isWalking");
        isWalkingHash = Animator.StringToHash("isRunning");

        //callbacks
        playerInput.CharacterConrols.Move.started += onMovementInput;
        playerInput.CharacterConrols.Move.canceled += onMovementInput;
        playerInput.CharacterConrols.Move.performed += onMovementInput;
        playerInput.CharacterConrols.Run.started += onRun;
        playerInput.CharacterConrols.Run.canceled += onRun;

        playerInput.CharacterConrols.Jump.started += onJump;
        playerInput.CharacterConrols.Jump.canceled += onJump;

        setUpJumpVariables();
    }
        void setUpJumpVariables()
        {
            float timeToApex = maxJumpTime / 2;
            gravity = (-2 * maxJumpHeight) / Mathf.Pow(timeToApex, 2);
            initialJumpVelocity = (2 * maxJumpHeight) / timeToApex;
        }

        void handleJump()
        {
            

            if (!isJumping && characterController.isGrounded && isJumpPressed)
            {
            animator.SetBool("isJumping", true);
                isJumping = true;
            currentMovement.y = initialJumpVelocity * jumpDistance; ;
                currentRunMovement.y = initialJumpVelocity * jumpDistance;
            }
            else if(!isJumpPressed && isJumping && characterController.isGrounded)
            {
                isJumping = false;
            }
        }
        void onJump(InputAction.CallbackContext context)
        {
            isJumpPressed = context.ReadValueAsButton();
        }

        void onRun(InputAction.CallbackContext context)
        {
            isRunPressed = context.ReadValueAsButton();
        }

        void onMovementInput(InputAction.CallbackContext context)
        {
            currentMovementInput = context.ReadValue<Vector2>();
            currentMovement.x = currentMovementInput.x * walkMultipler;
            currentMovement.z = currentMovementInput.y * walkMultipler;
            currentRunMovement.x = currentMovementInput.x * runMultipler;
            currentRunMovement.z = currentMovementInput.y * runMultipler;
            isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
        }

        void handleRotation()
        {
            Vector3 positionToLookAt;
            //change in characters rotation
            positionToLookAt.x = currentMovement.x;
            positionToLookAt.y = 0.0f;
            positionToLookAt.z = currentMovement.z;

            //used for rotation of our current character 
            Quaternion currentRotation = transform.rotation;

            if (isMovementPressed)
            {
                Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
                transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame * Time.deltaTime);
            }
        }

        void handleAnimation()
        {
            bool isWalking = animator.GetBool("isWalking");
            bool isRunning = animator.GetBool("isRunning");

            if (isMovementPressed && !isWalking)
            {
                animator.SetBool("isWalking", true);
            }

            else if (!isMovementPressed && isWalking)
            {
                animator.SetBool("isWalking", false);
            }

            if ((isMovementPressed && isRunPressed) && !isRunning)
            {
                animator.SetBool("isRunning", true);
            }

            else if ((!isMovementPressed || !isRunPressed) && isRunning)
            {
                animator.SetBool("isRunning", false);
            }


        }

         //Velocity verlet inegration 
        void handleGravity()
        {
        bool isFalling = currentMovement.y <= 0.0f || !isJumpPressed;
        float fallMultilpier = 2.0f;


            if (characterController.isGrounded)
            {
            animator.SetBool("isJumping", false);
                currentMovement.y = groundedGravity;
                currentRunMovement.y = groundedGravity;
            } else if (isFalling) 
              {

            float prevYVelocity = currentMovement.y;
            float newYVelocity = currentMovement.y  + (gravity * fallMultilpier * Time.deltaTime);
            float nextYVelocity = (prevYVelocity + newYVelocity) * .5f;
            currentMovement.y = nextYVelocity;
            currentRunMovement.y = nextYVelocity;
        }
            else
            {
                float prevYVelocity = currentMovement.y;
                float newYVelocity = currentMovement.y + (gravity * Time.deltaTime);
                float nextYVelocity = (prevYVelocity + newYVelocity) * .5f;
                currentMovement.y = nextYVelocity;
                currentRunMovement.y = nextYVelocity;
                currentMovement.y += gravity * Time.deltaTime;
                currentRunMovement.y += gravity * Time.deltaTime;
            }
        }
        void Update()
        {
            handleRotation();
            handleAnimation();
            if (isRunPressed)
            {
                characterController.Move(currentRunMovement * Time.deltaTime);
            }
            else
            {
                characterController.Move(currentMovement * Time.deltaTime);
            }
            handleGravity();
            handleJump();
        }

        void OnEnable()
        {
            playerInput.CharacterConrols.Enable();

        }

        void OnDisable()
        {
            playerInput.CharacterConrols.Disable();

        }

}
