using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookCC : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    public bool allowLooking = true;

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if(allowLooking == true)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.unscaledDeltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.unscaledDeltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }

    public void AllowLooking()
    {
        allowLooking = true;
    }
}
