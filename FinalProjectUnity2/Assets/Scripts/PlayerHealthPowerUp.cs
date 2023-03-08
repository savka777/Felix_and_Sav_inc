using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthPowerUp : MonoBehaviour
{
    public GameObject pickupEffect;
    public float invincibilityDuration = 5.0f;
    public float increaseSize = 2.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

        // Make player invincible
        playerHealth.isInvincible = true;
        player.transform.localScale *= increaseSize;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(invincibilityDuration);

        // Make player vulnerable again
        playerHealth.isInvincible = false;
        player.transform.localScale /= increaseSize;
        Destroy(gameObject);
    }
}

/*
 * NOTES: 
 * if player is invincibile
 * he cannot die, the timer must keep going, the death animation must not be triggered
 * the death explosion must not be triggered
 * 
 * 
 * 
 * 
 */