using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour
{
    public PlayerMovement movement;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch1 = Input.GetTouch(0);
            Vector3 touch_position = Camera.main.ScreenToWorldPoint(touch1.position);
        }

        
    }
}
