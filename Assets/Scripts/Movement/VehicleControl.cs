using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/* This script is a part of the ready-made scripts that TGL
 * provided us with. It handles vehicle movement in Unity at
 * runtime.
 * 
 * Last edited 01/06/2023 By Micael
 *  - Added comments
 */

[RequireComponent(typeof(VehicleInputProvider))]
public class VehicleControl : MonoBehaviour
{
    VehicleInputProvider inputProvider;
    private float Wheel => inputProvider.wheelInput;
    private float Throttle => usingWheelAndPedals ? LerpedInput(1, 0, inputProvider.throttleInput) : inputProvider.throttleInput;
    private float Brake => usingWheelAndPedals ? LerpedInput(0, 1, inputProvider.brakeInput) : inputProvider.brakeInput;
    private Vector2 Stick => inputProvider.joystickInput;

    [Header("Main")]
    [SerializeField] private Transform steeringWheel;
    [SerializeField] private float wheelRotationRange = 900f;
    [SerializeField] private float wheelMaxValue = 0.707f;

    [Header("Settings")]
    [SerializeField] private bool usingWheelAndPedals = true;
    [SerializeField] private float steeringPower = 50f;
    [SerializeField] private float speed = 2f;

    [Header("Debug")]
    [SerializeField] private bool debugEnabled;
    [SerializeField] private TMP_Text debugT;

    private void Awake()
    {
        inputProvider = GetComponent<VehicleInputProvider>();

        if (!debugEnabled && debugT)
            debugT.text = " ";
    }
    private void Update()
    {
        // Throttle & brake
        float velocity = Throttle - Brake;
        if (velocity > 0.01f || velocity < -0.01f)
            transform.Rotate(0, Wheel * steeringPower * Time.deltaTime, 0);

        transform.position += transform.forward * velocity * speed * Time.deltaTime;

        // Steering wheel
        if (steeringWheel)
        {
            Vector3 wheelRotation = steeringWheel.localEulerAngles;
            float wheelMax = Mathf.Lerp(0, 1f, (((Wheel / wheelMaxValue) + 1) / 2));
            wheelRotation.z = Mathf.Lerp(-wheelRotationRange / 2, wheelRotationRange / 2, wheelMax);
            steeringWheel.localEulerAngles = wheelRotation;
        }
    }
    private void FixedUpdate()
    {
        if (debugEnabled)
            UpdateDebug();
    }
    private float LerpedInput(float a, float b, float inputValue)
    {
        return inputProvider.enabled ? Mathf.Lerp(a, b, (inputValue + 1) / 2) : 0;
    }
    private void UpdateDebug()
        => debugT.text = $"Wheel: {Wheel:F3}\n" +
                         $"Throttle: {Throttle:F3}\n" +
                         $"Brake: {Brake:F3}\n" +
                         $"Stick: {Stick:F3}";
}