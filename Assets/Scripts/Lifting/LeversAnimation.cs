using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script handles the animation of the levers
 * imitates the movement of the levers in the control panel
 * and updates them accordingly in the model 
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

    public float speed = 15f;
    private float forkInputY => inputProvider.forkInputY;
    private float forkInputX => inputProvider.forkInputX;
    private float forkInputSpread => inputProvider.forkInputSpread;
    private float forkInputTilt => inputProvider.forkInputTilt;

    float angleInputY = 0;
    float angleInputX = 0;
    float angleInputSpread = 0;
    float angleInputTilt = 0;

    private void Update()
    {
        // Limit the angle in between -15 and 15
        angleInputY = Mathf.Clamp(forkInputY * speed, -15, 15);
        angleInputX = Mathf.Clamp(forkInputX * speed, -15, 15);
        angleInputSpread = Mathf.Clamp(forkInputSpread * speed, -15, 15);
        angleInputTilt = Mathf.Clamp(forkInputTilt * speed, -15, 15);

        //Apply the rotation
        lever1.transform.localRotation = Quaternion.AngleAxis(angleInputY, -Vector3.right);
        lever2.transform.localRotation = Quaternion.AngleAxis(angleInputX, -Vector3.right);
        lever3.transform.localRotation = Quaternion.AngleAxis(angleInputSpread, -Vector3.right);
        lever4.transform.localRotation = Quaternion.AngleAxis(angleInputTilt, Vector3.right);
    }
}
