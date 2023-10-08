using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool timeIsRunning=false;
    public float time;
    public int collisionNum;
    //start timer
    public void startTimer()
    {
        timeIsRunning = true;
    }

    //stop timer and send it's value to level complete function to be shown 
    public void stopTimer()
    {
        timeIsRunning = false;
        //return time;
        Debug.Log(time);
    }

    //public int collisionNumber()
    //{
    //    collisionNum++;
    //    if (timeIsRunning==false)
    //    return 
    //}
    // the pannel that apears at the end of the task
    public void levelComplete()
    {
       
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeIsRunning == false)
        {
            time += Time.deltaTime;
        }
        
    }
}
