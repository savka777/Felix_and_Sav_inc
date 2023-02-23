using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float startTime;
    private bool timerIsRunning = false;

    private void Start()
    {
        // Set the start time when the scene loads
        startTime = Time.time;
        timerIsRunning = true;
    }

    private void Update()
    {
        if (timerIsRunning)
        {
            // Calculate the time elapsed since the timer started and display it
            float elapsedTime = Time.time - startTime;
            string minutes = ((int)elapsedTime / 60).ToString("00");
            string seconds = (elapsedTime % 60).ToString("00");
            timerText.text = $"{minutes}:{seconds}";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EndObjective"))
        {
            // Stop the timer when the player reaches the end objective
            timerIsRunning = false;
        }
    }
}
