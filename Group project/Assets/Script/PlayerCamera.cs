using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private string mouseXInputName, mouseYInputName;
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private Transform playerbody;

    private float xAxisMax; //  -90 <= the camera view <= 90

    private void Awake()
    {
        LockCursor();
        xAxisMax = 0.0f;
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        CameraRotation();
    }

    private void CameraRotation()
    {
        float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * Time.deltaTime;

        xAxisMax += mouseY;
        if(xAxisMax > 90.0f)
        {
            xAxisMax = 90.0f;
            mouseY = 0.0f;
            RotationControl(270.0f);
        }
        else if (xAxisMax < -90.0f)
        {
            xAxisMax = -90.0f;
            mouseY = 0.0f;
            RotationControl(90.0f);
        }

        transform.Rotate(Vector3.left * mouseY);
        playerbody.Rotate(Vector3.up * mouseX);
    }


    private void RotationControl(float input)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = input;
        transform.eulerAngles = eulerRotation;
    }
}
