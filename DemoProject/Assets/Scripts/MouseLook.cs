using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    float mousex, mousey;
    public float sensitivity = 100f;
    public Transform playerbody;
    float xRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        mousex = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        mousey = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        playerbody.Rotate(Vector3.up * mousex);
        xRotation -= mousey;
        xRotation = Mathf.Clamp(xRotation, -90f, 60f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
