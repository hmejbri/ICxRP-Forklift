using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI endScreenText;
    [SerializeField] TextMeshProUGUI taskStatus;

    private bool timeIsRunning = false, timeIsUp = false;
    [HideInInspector] public float time;
    [HideInInspector] public int collisionNum;
    public int nbCollisionAccepted;
    public Light redLight;

    //start timer
    public void startTimer()
    {
        timeIsRunning = true;
    }

    //stop timer and send it's value to level complete function to be shown 
    public void stopTimer()
    {
        timeIsRunning = false;
        timeIsUp = true;
    }

    public string DisplayTime(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        if(minutes > 1)
            return string.Format("{0:00} minutes and {1:00} seconds", minutes, seconds);
        else if (minutes == 0)
            return string.Format("{0:00} seconds", seconds);
        else
            return string.Format("{0:00} minute and {1:00} seconds", minutes, seconds);
    }

    public void detectCollision()
    {
        if (timeIsUp == false)
            collisionNum++; 

        redLight.GetComponent<Light>().intensity = 5;
    }

    // the pannel that appears at the end of the task
    public void levelComplete()
    {
        if (timeIsUp == true)
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
                taskStatus.text = "Tutorial Completed !";
            else
            {
                if (collisionNum > 0)
                    taskStatus.text = "Task Failed !";
                else
                    taskStatus.text = "Task Completed !";

                endScreenText.text = "You bumped into objects " + collisionNum +
                        (collisionNum != 1 ? " times" : " time") + "\n\nYou finished the task in " + DisplayTime(time);
            }
        }
    }


    void Start()
    {
        //we will start the timer here and stop it in the last step of the task 
        startTimer();
        redLight.GetComponent<Light>().intensity = 0;
    }

    void Update()
    {
        if (timeIsRunning)
            time += Time.deltaTime;
    }
}
