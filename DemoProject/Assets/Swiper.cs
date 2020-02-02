using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swiper : MonoBehaviour
{
    private Touch initTouch = new Touch();
    //public Camera cam;
    public Transform playerbody;

    private float xRotation = 0f, yRotation = 0f;
    private Vector3 orgRotation;

    public float sensitivity = 0.5f;
    public float dir = -1f;


    void Start()
    {
        orgRotation = transform.eulerAngles;
        xRotation = orgRotation.x;
        yRotation = orgRotation.y;
    }

    void FixedUpdate()
    {
        foreach(Touch touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Began)
            {
                initTouch = touch;
            }
            else if(touch.phase == TouchPhase.Moved)
            {
                //swiping
                float deltax = touch.position.x - initTouch.position.x;
                float deltay = touch.position.y - initTouch.position.y;

                //xRotation -= deltax * Time.deltaTime;
                //yRotation += deltay * Time.deltaTime;

                //transform.eulerAngles = new Vector3(yRotation, xRotation, 0f);
                playerbody.Rotate(Vector3.up * deltax * sensitivity * Time.deltaTime);
                xRotation -= deltay * sensitivity * Time.deltaTime;
                transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            }
            else if(touch.phase == TouchPhase.Ended)
            {
                initTouch = new Touch();
            }
        }
    }
}
