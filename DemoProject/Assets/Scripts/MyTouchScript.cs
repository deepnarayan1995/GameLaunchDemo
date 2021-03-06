﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTouchScript : MonoBehaviour
{
    public VirtualJoystick moveJoystick;
    public FixedButton jumpButton;
    public FixedTouchField touchField;

    void Start()
    {
        
    }

    void Update()
    {
        var fps = GetComponent<PlayerMovement>();
        var fpslook = GetComponentInChildren<MouseLook>();

        fps.RunAxis = moveJoystick.InputDirection;
        fps.JumpAxis = jumpButton.pressed;
        fpslook.LookAxis = touchField.touchDistance;
    }
}
