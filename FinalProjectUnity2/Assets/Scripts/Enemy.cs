using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;
    GameObject player;
    [SerializeField] public BoxCollider head;
    [SerializeField] Vector3 target1;
    [SerializeField] Vector3 target2;

    CharacterController character;
    Vector3 direction;

    //Jumping code

    
    
    public int damage = 100;

    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        animator.SetBool("IsWalking", true);
        character = GetComponent<CharacterController>();
        target1.y = gameObject.transform.position.y;
        target2.y = gameObject.transform.position.y;
        direction = (target1) - (gameObject.transform.position);
        //StartCoroutine(ranJumpCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target1) < 0.5f)
        {
            direction = (target2) - (gameObject.transform.position);
        }
        if (Vector3.Distance(transform.position, target2) < 0.5f)
        {
            direction = (target1) - (gameObject.transform.position);
        }
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) < 5f)
        {
            direction = (player.transform.position) - (gameObject.transform.position);
        }




        direction.Normalize();

        character.Move(direction * Time.deltaTime * 3);
        Vector3 minDirection = new Vector3(0, direction.y, 0);
        transform.rotation = Quaternion.LookRotation(direction - (minDirection));
    }
    public void Die()
    {
        Destroy(gameObject);
    }


    IEnumerator ranJumpCoroutine()
    {
        do
        {
            float currentHight = transform.position.y;
            int ran = Random.Range(1, 11);
            int i = 0;
            yield return new WaitForSeconds(ran);
            do
            {
                character.Move(Vector3.up *  0.1f * Time.deltaTime);
                yield return new WaitForSeconds(0.01f);
                i++;
            } while (i <= 10);
            yield return new WaitForSeconds(5f);

        } while (true);
    }
    private void OnTriggerEnter(Collider other)
    {
        AnimationMovementController animovement = other.GetComponent<AnimationMovementController>();
        if (animovement)
        {
            animator.SetBool("IsPunch", true);
        }

        if (other.CompareTag("Player"))
        {
            if (!animovement.invJump)
            {
                PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
                playerHealth.TakeDamage(damage);
            }
        }

    }
}
