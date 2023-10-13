using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script detects when the cargo is placed inside the
 * attached GameObject's trigger zone. After 3 seconds, the
 * task will register as completed.
 * 
 * Last edited 12/10/2023 by Micael
 */

public class Task3FinishZone : MonoBehaviour
{
    [SerializeField] private TaskEndScreen taskEndScreen; // For ending UI

    private bool isCountingDown = false;
    private float countdownTime = 3.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("cargo"))
        {
            StartCountdown();
        }
    }

    private void Update()
    {
        if (isCountingDown)
        {
            countdownTime -= Time.deltaTime;

            if (countdownTime <= 0)
            {
                CountdownFinished();
            }
        }
    }

    private void StartCountdown()
    {
        isCountingDown = true;
        Debug.Log("Countdown started!");
    }

    private void CountdownFinished()
    {
        isCountingDown = false;
        Debug.Log("Countdown finished!");

        // Add finish here
        taskEndScreen.ShowScreen();
    }
}
