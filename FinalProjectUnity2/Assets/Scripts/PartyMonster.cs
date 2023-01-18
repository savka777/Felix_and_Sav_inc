using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyMonster : MonoBehaviour
{
    private bool IsWalking;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        transform.position += new Vector3(inputX,0, inputY) * 4 * Time.deltaTime;
        if (inputX != 0 || inputY != 0)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }
}
