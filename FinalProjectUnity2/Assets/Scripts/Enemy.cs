using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;
    GameObject player;
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
}

// Update is called once per frame
void Update()
{
    Vector3 noFly = new Vector3(player.transform.position.x,gameObject.transform.position.y,player.transform.position.z);
    Vector3 direction = (noFly) - (gameObject.transform.position);
    direction.Normalize();
    transform.position += direction *3* Time.deltaTime;
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
}
