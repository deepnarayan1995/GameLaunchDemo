using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedTouchFieldTest : MonoBehaviour
{
    private Touch initTouch = new Touch();

    public Transform playerBody;
    public Camera cam;

    private float mouseX, mouseY, xRotation;
    //private Vector3 orgRotation;
    public float sensitivity = 10f;

    [HideInInspector]
    public Vector2 touchDistance;
    [HideInInspector]
    public Vector2 PntrOld;
    private int PntrId;


    void Start()
    {
        //orgRotation = cam.transform.eulerAngles;
        //mouseX = orgRotation.x;
        //mouseY = orgRotation.y;
    }

    void Update()
    {
        foreach(Touch touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Began)
            {
                initTouch = touch;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                mouseX = touch.position.x - initTouch.position.x;
                mouseY = touch.position.y - initTouch.position.y;

                playerBody.Rotate(Vector3.up * mouseX * sensitivity * Time.deltaTime);

                xRotation -= mouseY * sensitivity * Time.deltaTime;
                cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                initTouch = new Touch();
            }
        }
    }
}
