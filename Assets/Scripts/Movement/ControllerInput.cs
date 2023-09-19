using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Diagnostics;

public class ControllerInput : MonoBehaviour
{
    [HideInInspector] public int gearValue { get; private set; }
    [HideInInspector] public float[] joystickValues { get; private set; }
    [HideInInspector] public int errorCode { get; private set; }

    [SerializeField] string portName;
    List<string> portNames;
    SerialPort port;
    string input;

    Regex regexString = new Regex(@"^-?[0-1](?:\|-?(?:0\.[0-9]{2}|1\.00)){4}$");

    private void Start()
    {
        joystickValues = new float[] { 0, 0, 0, 0 };

        //If COM-port is not set manually, find and assing correct port name
        if (portName == "")
        {
            portNames = GetSerialPortCaptions();

            foreach (string _portName in portNames)
            {
                if (_portName.Contains("CH340"))
                {
                    portName = _portName.Substring(_portName.IndexOf('(') + 1, _portName.IndexOf(')') - _portName.IndexOf('(') - 1);
                }
            }

            if (portName == "") { errorCode = 1; return; } //No device found
        }

        port = new SerialPort(portName);
    }

    private void Update()
    {
        //Reading controller values from serial port
        if (port == null) { return; }

        try
        {
            if (!port.IsOpen)
            {
                port.Open();
            }    
        }
        catch (IOException)
        {
            errorCode = 2; //Serial port already in use
            return;
        }

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

    private void FixedUpdate()
    {
        if (port.IsOpen) { input = port.ReadLine(); }
    }

    public static List<string> GetSerialPortCaptions()
    {
        List<string> captions = new List<string>();

        Process process = new Process();
        process.StartInfo.FileName = "powershell.exe";
        process.StartInfo.Arguments = @"Get-WmiObject -Class Win32_PnPEntity | Where-Object { $_.Caption -like '*(COM*' } | Select-Object -ExpandProperty Caption";
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.CreateNoWindow = true;
        process.Start();

        string output = process.StandardOutput.ReadToEnd();
        process.WaitForExit();

        if (process.ExitCode != 0)
        {
            UnityEngine.Debug.LogWarning("PowerShell command exited with error code: " + process.ExitCode);
        }

        if (!string.IsNullOrEmpty(output))
        {
            string[] lines = output.Split('\n');
            foreach (string line in lines)
            {
                string trimmedLine = line.Trim();
                if (!string.IsNullOrEmpty(trimmedLine))
                {
                    captions.Add(trimmedLine);
                }
            }
        }

        return captions;
    }
}
