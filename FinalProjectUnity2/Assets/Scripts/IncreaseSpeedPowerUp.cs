using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseSpeedPowerUp : MonoBehaviour
{ 


    public GameObject pickupEffect;
    public float speedMultiplier = 2.0f;
    public float powerUpDuration = 5.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other.gameObject));
        }
    }

    IEnumerator Pickup(GameObject playerObject)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        AnimationMovementController playerMovement = playerObject.GetComponent<AnimationMovementController>();

        // Increase player's speed
        playerMovement.runMultipler *= speedMultiplier;
        playerMovement.walkMultipler *= speedMultiplier;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(powerUpDuration);

        // Decrease player's speed
        playerMovement.runMultipler /= speedMultiplier;
        playerMovement.walkMultipler /= speedMultiplier;

        Destroy(gameObject);
    }
}

