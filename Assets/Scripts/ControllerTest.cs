using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControllerTest : MonoBehaviour
{
    [SerializeField] ControllerInput input;
    [SerializeField] TMP_Text gear;
    [SerializeField] TMP_Text joystick1;
    [SerializeField] TMP_Text joystick2;
    [SerializeField] TMP_Text joystick3;
    [SerializeField] TMP_Text joystick4;
    [SerializeField] TMP_Text errorCode;

    private void Update()
    {
        gear.text = input.gearValue.ToString();
        joystick1.text = input.joystickValues[0].ToString();
        joystick2.text = input.joystickValues[1].ToString();
        joystick3.text = input.joystickValues[2].ToString();
        joystick4.text = input.joystickValues[3].ToString();
        errorCode.text = input.errorCode.ToString();
    }
}
