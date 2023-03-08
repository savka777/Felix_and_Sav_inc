using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // ParticleSystem explosion;
    public GameObject explosionEffect;
    public int health = 100;
    public GameObject LoseScreen;
    AnimationMovementController amc;
    public bool isInvincible = false;


    private void Start()
    {
      //explosion = GetComponent<ParticleSystem>();
    }
    void Update()
    {
        
        if (health <= 0)
        {
            
            Die();
  
        }
    }

    void ShowLoseScreen()
    {
        LoseScreen.SetActive(true);
    }

    void Die()
    {
        Debug.Log("Player died.");
        Timer timer = FindObjectOfType<Timer>();
        if (timer != null)
        {
            timer.timerIsRunning = false;
        }

        Invoke("ShowLoseScreen", .80f);

        //bug need fixing, camera needs to be attached outside of player or else everything gets destroyed
       // Destroy(gameObject, 1.0f);

       
    }

    public void TakeDamage(int damage)
    {
            if (!isInvincible)
            {
                health -= damage;
            }
        }
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
        }
       
    }
}
