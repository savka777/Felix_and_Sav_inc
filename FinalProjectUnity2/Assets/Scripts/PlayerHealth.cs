using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public GameObject LoseScreen;
    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player died.");
        LoseScreen.SetActive(true);
        // Add code to handle player death here, such as displaying a game over message or restarting the game.
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}