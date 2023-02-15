using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowParticles : MonoBehaviour
{

    public Transform hand;
    public ParticleSystem particleSystem;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        // Update the particle system's position to match the hand object's position
        particleSystem.transform.position = hand.position;
        // Update the particle system's rotation to match the hand object's rotation
        particleSystem.transform.rotation = hand.rotation;
    }
}

