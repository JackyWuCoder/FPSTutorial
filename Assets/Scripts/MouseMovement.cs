using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 1.0f;
    private float xRotation = 0.0f;
    private float yRotation = 0.0f;
    [SerializeField] private float xRotationLowerClamp = -90.0f;
    [SerializeField] private float xRotationUpperClamp = 90.0f;

    // Start is called before the first frame update
    private void Start()
    {
        // Locking the cursor to the middle of the screen and making it invisible
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update()
    {
        // Getting the mouse delta inputs
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotation around the x-axis (Look up and down)
        xRotation -= mouseY;

        // Clamp the rotation
        xRotation = Mathf.Clamp(xRotation, xRotationLowerClamp, xRotationUpperClamp);

        // Rotation around the y-axis (Look left and right)
        yRotation += mouseX;

        // Apply rotations to our transform
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
