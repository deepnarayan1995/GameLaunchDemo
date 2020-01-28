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


    void Update()
    {
        xval = Input.GetAxis("Horizontal");
        zval = Input.GetAxis("Vertical");

        Vector3 moving = transform.right * xval + transform.forward * zval;
        controller.Move(moving * speed * Time.deltaTime);

    }
}
