using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

/* This script is a part of the ready-made scripts that TGL
 * provided us with. It handles inputs for the vehicle driving
 * and also includes value references for debugging
 * 
 * Last edited 01/06/2023 By Micael
 *  - Added comments
 */

public class VehicleInputProvider : MonoBehaviour
{
    // Reference: Assets/ScriptableObjects/Inputs/Vehicle Input Actions
    [Header("Main Input")]
    [SerializeField] private InputActionAsset actionAsset;
    [SerializeField] private InputActionReference wheelReference;
    [SerializeField] private InputActionReference throttleReference;
    [SerializeField] private InputActionReference brakeReference;

    [Header("Other Input")]
    [SerializeField] private InputActionReference joystickReference;

    [Header("Debug")]
    [SerializeField] private bool debugEnabled;
    [SerializeField] private TMP_Text debugT;

    private float wheelInput;
    private float throttleInput;
    private float brakeInput;
    private Vector2 joystickInput;

    /* If enabled, give wheelInput value to WheelInput, otherwise give value 0. Works as a getter
     * to stay updated in runtime. This took me an insanely long time to understand, refer to
     * ternary operators for more info
     * - Micael
     */
    public float WheelInput => enabled ? wheelInput : 0;
    public float ThrottleInput => enabled ? throttleInput : 0;
    public float BrakeInput => enabled ? brakeInput : 0;
    public Vector2 JoystickInput => enabled ? joystickInput : new Vector2(0, 0);

    private void Awake()
    {
        actionAsset.Enable();
        if (!debugEnabled && debugT)
            debugT.text = " ";
    }
    private void Update()
    {
        if (wheelReference)
            wheelInput = wheelReference.action.ReadValue<Vector2>().x;
        if (throttleReference)
            throttleInput = throttleReference.action.ReadValue<float>();
        if (brakeReference)
            brakeInput = brakeReference.action.ReadValue<float>();
        if (joystickReference)
            joystickInput = joystickReference.action.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        if (debugEnabled)
            UpdateDebug();
    }
    private void UpdateDebug()
        => debugT.text = $"Wheel: {WheelInput:F3}\n" +
                         $"Throttle: {ThrottleInput:F3}\n" +
                         $"Brake: {BrakeInput:F3}\n" +
                         $"Joystick: {JoystickInput}";
}