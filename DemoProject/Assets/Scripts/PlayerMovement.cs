using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float xval, zval;
    public float speed = 6f;
    public CharacterController controller;
    public float gravity = 9.8f, jumpheight = 3f;
    Vector3 velocity;

    [HideInInspector]
    public Vector2 RunAxis;
    public bool JumpAxis;

    public VirtualJoystick movejoystick;
    private Transform camTransform;

    void Start()
    {
        camTransform = Camera.main.transform;
    }


    void Update()
    {
        if(controller.isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        Vector3 dir = Vector3.zero;
        dir = movejoystick.InputDirection;

        Vector3 newDir = camTransform.TransformDirection(dir);
        newDir = new Vector3(newDir.x, 0, newDir.z);
        newDir = newDir.normalized * dir.magnitude;
        controller.Move(newDir * speed * Time.deltaTime);

        //xval = RunAxis.x;
        //zval = RunAxis.y;//this is z value

        //Vector3 moving = transform.right * xval + transform.forward * zval;
        //controller.Move(moving * speed * Time.deltaTime);
               

        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (JumpAxis && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpheight * 2f * gravity);
        }

    }
}
