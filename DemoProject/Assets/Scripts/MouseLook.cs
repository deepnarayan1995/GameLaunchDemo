using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    float mousex, mousey;
    public float sensitivity = 100f;
    public Transform playerbody;
    float xRotation;

    [HideInInspector]
    public Vector2 LookAxis;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        mousex = LookAxis.x * sensitivity;
        mousey = LookAxis.y * sensitivity;

        playerbody.Rotate(Vector3.up * mousex);
        xRotation -= mousey;
        xRotation = Mathf.Clamp(xRotation, -90f, 60f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
