using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    ParticleSystem explosion;
    public int health = 100;
    public GameObject LoseScreen;
    AnimationMovementController amc;

   
    private void Start()
    {
      explosion = GetComponent<ParticleSystem>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
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

        Invoke("ShowLoseScreen", .80f);

        //bug need fixing, camera needs to be attached outside of player or else everything gets destroyed
       /// Destroy(gameObject, 1.0f);

        // Add code to handle player death here, such as displaying a game over message or restarting the game.
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            explosion.Play();
           
        }
       
    }
}
