using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ControllerInput : MonoBehaviour
{
    [HideInInspector] public int gearValue { get; private set; }
    [HideInInspector] public float[] joystickValues { get; private set; }

    public string portName;
    public SerialPort port;

    private void Start()
    {
        port = new SerialPort(portName);

        port.Open();
        joystickValues = new float[] { 0, 0, 0, 0 };
    }

    private void Update()
    {
        if (port.IsOpen)
        {
            //Reading controller values from serial port
            string input = port.ReadLine();
            string[] inputValues = input.Split("|");

            //Parsing the controller values to usable variables
            gearValue = int.Parse(inputValues[0]);
            for (int i = 1; i <= 4; i++)
            {
                joystickValues[i - 1] = float.Parse(inputValues[i]);
            }
        }
    }
}
