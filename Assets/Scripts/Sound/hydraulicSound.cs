using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hydraulicSound : MonoBehaviour
{
    [SerializeField] GameObject forklift;
    [SerializeField] AudioSource hydraulics_end;

    private AudioSource hydraulicsAudio;
    private float forkY;
    private float forkX;
    private float forkTilt;
    private float forkSpread;
    private bool started = false;

    void Start()
    {
        hydraulicsAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        Hydraulics();
    }

    void Hydraulics()
    {
        forkY = forklift.GetComponent<VehicleInputProvider>().forkInputY;
        forkX = forklift.GetComponent<VehicleInputProvider>().forkInputX;
        forkTilt = forklift.GetComponent<VehicleInputProvider>().forkInputTilt;
        forkSpread = forklift.GetComponent<VehicleInputProvider>().forkInputSpread;

        float sum = forkY + forkX + forkSpread + forkTilt;

        if (sum != 0 && !started)
        {
            hydraulicsAudio.Play();
            started = true;
        }
        else if (sum == 0 && started)
        {
            hydraulicsAudio.Stop();
            hydraulics_end.Play();
            started = false;
        }

    }
}
