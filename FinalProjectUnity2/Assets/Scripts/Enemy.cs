using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject player;
    Animator animator;
    void Start()
    {
        player = GameObject.Find("C02");
        animator = GetComponent<Animator>();
        animator.SetBool("IsWalking", false);
    }

   
    void Update()
    {
        Vector3 direction = (player.transform.position) - (gameObject.transform.position);
        direction.Normalize();
        transform.position += direction * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
