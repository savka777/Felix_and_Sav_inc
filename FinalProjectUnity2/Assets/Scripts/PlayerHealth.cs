
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public float invincibilityDuration = 5.0f;
    public GameObject LoseScreen;
    public bool isInvincible = false;
    public bool isDead = false;
    public GameObject explosionEffect;

    private void Update()
    {
        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Player died.");
        isDead = true;

        // Stop the timer
        Timer timer = FindObjectOfType<Timer>();
        if (timer != null)
        {
            timer.timerIsRunning = false;
        }

        // Show the lose screen
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Invoke("ShowLoseScreen", .99f);

        // Destroy the player
        // Destroy(gameObject);
    }
    void ShowLoseScreen()
    {
        LoseScreen.SetActive(true);
    }

    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            health -= damage;
        }
    }

    public void MakeInvincible()
    {
        isInvincible = true;
        StartCoroutine(DisableInvincibility());
    }

    IEnumerator DisableInvincibility()
    {
        yield return new WaitForSeconds(invincibilityDuration);
        isInvincible = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (!isInvincible && isDead)
            {

                Die();
            }
        }
    }
}

