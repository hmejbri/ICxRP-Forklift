using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class engineSound : MonoBehaviour
{
    [SerializeField] GameObject forklift;

    public float minSpeed;
    public float maxSpeed;
    private float currentSpeed;

    private AudioSource carAudio;

    public float minPitch;
    public float maxPitch;
    private float pitchFromCar;

    void Start()
    {
        carAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        EngineSound();
    }

    void EngineSound()
    {
        currentSpeed = forklift.GetComponent<VehicleControl>().velocity;
        pitchFromCar = forklift.GetComponent<VehicleControl>().velocity / 60f;

        if (currentSpeed == minSpeed)
        {
            carAudio.pitch = minPitch;
        }

        if (currentSpeed > minSpeed && currentSpeed < maxSpeed)
        {
            carAudio.pitch = minPitch + pitchFromCar;
        }

        if (currentSpeed == maxSpeed)
        {
            carAudio.pitch = maxPitch;
        }
    }
}
