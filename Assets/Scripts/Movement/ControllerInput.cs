using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Text.RegularExpressions;

public class ControllerInput : MonoBehaviour
{
    [HideInInspector] public int gearValue { get; private set; }
    [HideInInspector] public float[] joystickValues { get; private set; }
    [HideInInspector] public int errorCode { get; private set; }

    public string portName;
    SerialPort port;

    Regex regexString = new Regex(@"^-?[0-1](?:\|-?(?:0\.[0-9]{2}|1\.00)){4}$");

    private void Start()
    {
        port = new SerialPort(portName);
        port.Open();
        joystickValues = new float[] { 0, 0, 0, 0 };
    }

    private void Update()
    {
        //Reading controller values from serial port
        string input = port.ReadLine();
        if (regexString.IsMatch(input))
        {
            string[] inputValues = input.Split("|");

            //Parsing the controller values to usable variables
            gearValue = int.Parse(inputValues[0]);
            for (int i = 1; i <= 4; i++)
            {
                joystickValues[i - 1] = float.Parse(inputValues[i]);
            }

            errorCode = 0; //No error detected
        }
        else
        {
            errorCode = 3; //Invalid dataformat
        }
    }
}
