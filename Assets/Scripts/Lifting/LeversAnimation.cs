using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script handles the animation of the levers
 * imitates the movement of the levers in the control panel
 * and update them accordingly in the model 
 * 
 * Last editor : Houssem 
 */

[RequireComponent(typeof(VehicleInputProvider))]
public class LeversAnimation : MonoBehaviour
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

        // Limit the angle in between -10 and 10
        angleInputY = Mathf.Clamp(angleInputY, -10, 10);
        angleInputX = Mathf.Clamp(angleInputX, -10, 10);
        angleInputSpread = Mathf.Clamp(angleInputSpread, -10, 10);
        angleInputTilt = Mathf.Clamp(angleInputTilt, -10, 10);

        //Apply the rotation
        lever1.transform.localRotation = Quaternion.AngleAxis(angleInputY, Vector3.right);
        lever2.transform.localRotation = Quaternion.AngleAxis(angleInputX, Vector3.right);
        lever3.transform.localRotation = Quaternion.AngleAxis(angleInputSpread, Vector3.right);
        lever4.transform.localRotation = Quaternion.AngleAxis(angleInputTilt, Vector3.right);
    }
}
