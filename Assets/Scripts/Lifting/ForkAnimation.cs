using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(VehicleInputProvider))]
public class ForkAnimation : MonoBehaviour
{
    [SerializeField] VehicleInputProvider inputProvider; //Forklift game object
    [SerializeField] GameObject lever1;
    [SerializeField] GameObject lever2;
    [SerializeField] GameObject lever3;
    [SerializeField] GameObject lever4;

    private float forkInputY => inputProvider.joystickInput.y; // Keyboard: up/down arrow keys
    private float forkInputX => inputProvider.joystickInput.x; // Keyboard: left/right arrow keys
    private float forkInputSpread => inputProvider.forkSpreadInput; // Keyboard: Q and E
    private float forkInputTilt => inputProvider.forkTiltInput; // Keyboard: Z and X

    float angleInputY = 0;
    float angleInputX = 0;
    float angleInputSpread = 0;
    float angleInputTilt = 0;

    private void Update()
    {
        angleInputY += forkInputY;
        angleInputX += forkInputX;
        angleInputSpread += forkInputSpread;
        angleInputTilt += forkInputTilt;

        angleInputY = Mathf.Clamp(angleInputY, -10, 10);
        angleInputX = Mathf.Clamp(angleInputX, -10, 10);
        angleInputSpread = Mathf.Clamp(angleInputSpread, -10, 10);
        angleInputTilt = Mathf.Clamp(angleInputTilt, -10, 10);

        lever1.transform.localRotation = Quaternion.AngleAxis(angleInputY, Vector3.right);
        lever2.transform.localRotation = Quaternion.AngleAxis(angleInputX, Vector3.right);
        lever3.transform.localRotation = Quaternion.AngleAxis(angleInputSpread, Vector3.right);
        lever4.transform.localRotation = Quaternion.AngleAxis(angleInputTilt, Vector3.right);
    }
}