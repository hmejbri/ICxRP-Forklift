using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beeping : MonoBehaviour
{
    [SerializeField] GameObject forklift;

    private AudioSource beepingAudio;
    private float currentSpeed;
    private bool started = false;

    void Start()
    {
        beepingAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        BeepingSound();
    }

    void BeepingSound()
    {
        currentSpeed = forklift.GetComponent<VehicleControl>().velocity;

        if (currentSpeed < 0 && !started)
        {
            beepingAudio.Play();
            started = true;
        }
        else if (currentSpeed >= 0 && started)
        {
            beepingAudio.Stop();
            started = false;
        }
        
    }
}
