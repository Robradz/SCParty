using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GamepadLook : MonoBehaviour
{
    [SerializeField] private string mouseXInput, mouseYInput;
    [SerializeField] private float mouseSensitivity;

    [SerializeField] private float xMax = 90f;
    [SerializeField] private float xMin = -90f;

    [SerializeField] private Transform playerBody;
    [SerializeField] Camera playerCamera;

    private float xAxisClamp = 0;

    Vector2 lookRotation;

    public float turnAmount;

    private void Awake()
    {
        LockCursor();
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraRotation();
    }

    void OnLook(InputValue value)
    {
        lookRotation = value.Get<Vector2>();
    }

    private void CameraRotation()
    {
        float rotationX = lookRotation.x * mouseSensitivity * Time.deltaTime;
        float rotationY = lookRotation.y * mouseSensitivity * Time.deltaTime;

        xAxisClamp += rotationY;
        turnAmount = lookRotation.x;

        if (xAxisClamp > xMax)
        {
            xAxisClamp = xMax;
            rotationY = 0.0f;
            ClampXAxisRotationToValue(0f);
        }
        else if (xAxisClamp < xMin)
        {
            xAxisClamp = xMin;
            rotationY = 0.0f;
            ClampXAxisRotationToValue(0f);
        }

        playerCamera.transform.Rotate(Vector3.left * rotationY);
        playerBody.Rotate(Vector3.up * rotationX);
    }

    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }

}
