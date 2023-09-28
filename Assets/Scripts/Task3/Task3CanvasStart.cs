using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script controls the first canvas that appears at
 * the start of task 3. It is shown for x seconds, then it
 * disappears.
 * 
 * Last edited 18/09/2023 by Micael
 */

public class Task3CanvasStart : MonoBehaviour
{

    public Canvas canvas; // Reference to canvas
    public float displayTime = 10f;
    private float timer = 0f;
    private bool isCanvasActive = false;

    private void Start()
    {
        ShowCanvas();
    }

    private void Update()
    {
        if (isCanvasActive)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                canvas.enabled = false;
                isCanvasActive = false;
            }
        }
    }

    private void ShowCanvas()
    {
        canvas.enabled = true;
        isCanvasActive = true;
        timer = displayTime;
    }
}