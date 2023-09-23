using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script handles fork controls for the forklift
 * (up/down, left/right, spread, tilt)
 * 
 * Last edited 14/06/2023 By Micael
 *  - Added fork tilt movement
 *  - Added fork X movement
 *  - Cleaned up code a bit
 */

[RequireComponent(typeof(VehicleInputProvider))]
public class ForkControl : MonoBehaviour
{
    private VehicleInputProvider inputProvider;

    [Header("Transform references")]
    [SerializeField] private Transform forkRig; // Refer to Load_Backrest game object
    [SerializeField] private Transform forkLeft;
    [SerializeField] private Transform forkRight;
    [SerializeField] private Transform forkMast; // Refer to Central_mast game object

    // Note: the variables for fork movements need to be tested and adjusted for realism
    [Header("Fork Y movement")]
    [SerializeField] private float forkAdjustRigMaxY = 3f;
    [SerializeField] private float forkRigSpeedY = 1f;

    private float forkRigStartY;
    private float forkRigMaxY;
    private float forkRigPosY;

    [Header("Fork X movement")]
    [SerializeField] private float forkAdjustRigMaxX = 1f;
    [SerializeField] private float forkRigSpeedX = 1f;

    private float forkRigStartX;
    private float forkRigMaxX;
    private float forkRigPosX;

    [Header("Fork spread movement")]
    [SerializeField] private float forkAdjustMaxSpread = 1f;
    [SerializeField] private float forkSpreadSpeed = 1f;

    private float forkSpreadStart;
    private float forkSpreadMax;
    private float forkSpreadPosX;

    [Header("Fork tilt movement")]
    [SerializeField] private float forkAdjustMaxTilt = 5f;
    [SerializeField] private float forkTiltSpeed = 1f;

    private float forkTiltStart;
    private float forkTiltMax;
    private float forkTiltRotate;

    // Input readers (forkSpreadInput & forkTiltInput are only mapped to keyboard atm)
    private float forkInputY => inputProvider.forkInputY; // Keyboard: up/down arrow keys
    private float forkInputX => inputProvider.forkInputX; // Keyboard: left/right arrow keys
    private float forkInputSpread => inputProvider.forkInputSpread; // Keyboard: Q and E
    private float forkInputTilt => inputProvider.forkInputTilt; // Keyboard: Z and X

    private void Awake()
    {
        inputProvider = GetComponent<VehicleInputProvider>();

        // Setup max distances
        forkRigMaxY = forkRigStartY + forkAdjustRigMaxY;
        forkSpreadMax = forkSpreadStart + forkAdjustMaxSpread;
        forkRigMaxX = forkRigStartX + forkAdjustRigMaxX;
        forkTiltMax = forkTiltStart + forkAdjustMaxTilt;
    }
    private void Update()
    {
        // Fork Y movement
        forkRigPosY = Mathf.Clamp(forkRigPosY + forkInputY * Time.deltaTime * forkRigSpeedY, forkRigStartY, forkRigMaxY);
        // The Y movement is in Z argument for Vector3 because of the object rotation
        forkRig.transform.localPosition = new Vector3(forkRig.transform.localPosition.x, forkRig.transform.localPosition.y, forkRigPosY);

        // Fork X movement
        forkRigPosX = Mathf.Clamp(forkRigPosX + forkInputX * Time.deltaTime * forkRigSpeedX, -forkRigMaxX, forkRigMaxX);
        forkRig.transform.localPosition = new Vector3(forkRigPosX, forkRig.transform.localPosition.y, forkRig.transform.localPosition.z);

        // Fork spread
        forkSpreadPosX = Mathf.Clamp(forkSpreadPosX + forkInputSpread * Time.deltaTime * forkSpreadSpeed, -forkSpreadMax, forkSpreadMax);
        forkLeft.transform.localPosition = new Vector3(forkSpreadPosX, forkLeft.transform.localPosition.y, forkLeft.transform.localPosition.z);
        forkRight.transform.localPosition = new Vector3(-forkSpreadPosX, forkLeft.transform.localPosition.y, forkLeft.transform.localPosition.z);

        // Fork tilt
        forkTiltRotate = Mathf.Clamp(forkTiltRotate + forkInputTilt * Time.deltaTime * forkTiltSpeed, -forkTiltMax, forkTiltMax);
        forkMast.transform.localRotation = Quaternion.Euler(forkTiltRotate, forkMast.transform.localRotation.y, forkMast.transform.localRotation.z);
    }
}