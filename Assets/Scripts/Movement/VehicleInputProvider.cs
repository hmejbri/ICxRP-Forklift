using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

/* This script handles inputs for the vehicle driving
 * and also includes value references for debugging
 * 
 * Last edited 14/06/2023 By Micael
 *  - Added input reference for fork spread
 *  - Added input reference for fork tilt
 *  
 *  TODO:
 *  - Remove joystickReference
 *  - Add separate input references for fork movements (replacing joystickReference)
 */

public class VehicleInputProvider : MonoBehaviour
{
    // Reference: Assets/ScriptableObjects/Inputs/Vehicle Input Actions
    [Header("Main Inputs")]
    [SerializeField] private InputActionAsset actionAsset;
    [SerializeField] private InputActionReference wheelReference;
    [SerializeField] private InputActionReference throttleReference;
    [SerializeField] private InputActionReference brakeReference;
    [SerializeField] private InputActionReference joystickReference;
    [SerializeField] private InputActionReference forkSpreadReference;
    [SerializeField] private InputActionReference forkTiltReference;

    [Header("Debug")]
    [SerializeField] private bool debugEnabled;
    [SerializeField] private TMP_Text debugT;

    private float t_wheelInput;
    private float t_throttleInput;
    private float t_brakeInput;
    private Vector2 t_joystickInput;
    private float t_forkSpreadInput;
    private float t_forkTiltInput;

    /* If enabled, give t_wheelInput value to wheelInput, otherwise give value 0. Works as a getter
     * to stay updated in runtime. This took me an insanely long time to understand, refer to
     * ternary operators for more info
     * - Micael
     */
    public float wheelInput => enabled ? t_wheelInput : 0;
    public float throttleInput => enabled ? t_throttleInput : 0;
    public float brakeInput => enabled ? t_brakeInput : 0;
    public Vector2 joystickInput => enabled ? t_joystickInput : new Vector2(0, 0);
    public float forkSpreadInput => enabled ? t_forkSpreadInput : 0;
    public float forkTiltInput => enabled ? t_forkTiltInput : 0;

    private void Awake()
    {
        actionAsset.Enable();
        if (!debugEnabled && debugT)
            debugT.text = " ";
    }
    private void Update()
    {
        if (wheelReference)
            t_wheelInput = wheelReference.action.ReadValue<Vector2>().x;
        if (throttleReference)
            t_throttleInput = throttleReference.action.ReadValue<float>();
        if (brakeReference)
            t_brakeInput = brakeReference.action.ReadValue<float>();
        if (joystickReference)
            t_joystickInput = joystickReference.action.ReadValue<Vector2>();
        if (forkSpreadReference)
            t_forkSpreadInput = forkSpreadReference.action.ReadValue<float>();
        if (forkTiltReference)
            t_forkTiltInput = forkTiltReference.action.ReadValue<float>();
    }
    private void FixedUpdate()
    {
        if (debugEnabled)
            UpdateDebug();
    }
    private void UpdateDebug()
        => debugT.text = $"Wheel: {wheelInput:F3}\n" +
                         $"Throttle: {throttleInput:F3}\n" +
                         $"Brake: {brakeInput:F3}\n" +
                         $"Joystick: {joystickInput}";
}