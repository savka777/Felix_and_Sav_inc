using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float startTime;
    private bool timerIsRunning = false;
    private float countdownTime = 300f; // 5 minutes in seconds

private void Start()
    {
        // Set the start time to 5 minutes when the scene loads
        startTime = Time.time + countdownTime;
        timerIsRunning = true;
    }

    private void Update()
    {
        if (timerIsRunning)
        {
            // Calculate the time remaining in the countdown and display it
            float timeRemaining = startTime - Time.time;
            if (timeRemaining <= 0f)
            {
                // If the countdown has reached 0, stop the timer and display "00:00"
                timerIsRunning = false;
                timerText.text = "00:00";
            }
            else
            {
                // Convert the time remaining to minutes and seconds and display it
                string minutes = ((int)timeRemaining / 60).ToString("00");
                string seconds = (timeRemaining % 60).ToString("00");
                timerText.text = $"{minutes}:{seconds}";
            }
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