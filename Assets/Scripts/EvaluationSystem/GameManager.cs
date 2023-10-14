using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool timeIsRunning = false, timeIsUp = false;
    public float time;
    public int collisionNum;
    public int nbCollisionAccepted;
    public Light redLight;
    //start timer
    public void startTimer()
    {
        timeIsRunning = true;
        Debug.Log("time : "+time);
    }

    //stop timer and send it's value to level complete function to be shown 
    public void stopTimer()
    {
        timeIsRunning = false;
        timeIsUp = true;
        //return time;
        ;

    }

    public string DisplayTime(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00} {1:00}", minutes, seconds);

    }
    public void detectCollision()
    {
        if (timeIsUp == false)
        { collisionNum++; }
        redLight.GetComponent<Light>().intensity = 15;
        Debug.Log(collisionNum);
    }
    // the pannel that apears at the end of the task
    public void levelComplete()
    {
        if (timeIsUp == true)
        {

        }

    }


    // Start is called before the first frame update
    void Start()
    {//we will start the timer here and stop it in the last step of the task 
        startTimer();
        redLight.GetComponent<Light>().intensity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeIsRunning)
        {
            time += Time.deltaTime;
        }

    }
}
