using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float sensX;
    public float sensY;
    public float rotationLimXmin = -90f;
    public float rotationLimXmax = 90f;
    public float rotationLimYmin = -4320f;
    public float rotationLimYmax = 4320f;

    public Transform orientation;

    public float xRotation;
    public float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Time.fixedDeltaTime * sensX * Input.GetAxis("Mouse X");
        float mouseY = Time.fixedDeltaTime * sensY * Input.GetAxis("Mouse Y");

        yRotation += mouseX;
        yRotation = Mathf.Clamp(yRotation, rotationLimYmin, rotationLimYmax);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, rotationLimXmin, rotationLimXmax);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        orientation.rotation = Quaternion.Euler(0f, yRotation, 0f);
    }
}
