using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseSizePowerUp : MonoBehaviour
{
    public GameObject pickupEffect;
    public float increaseSize = 2.0f;
    // Start is called before the first frame update
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
        player.transform.localScale *= increaseSize;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(3.0f);
        player.transform.localScale /= increaseSize;
        Destroy(gameObject);
    }
}