using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam: MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xrotation;
    float yrotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime* sensY;

        yrotation += mouseX;
        xrotation -= mouseY;

        xrotation = Math.Clamp(xrotation, -90f, 90f);


        //for orientation and rotate cam 
        transform.rotation = Quaternion.Euler(xrotation, yrotation, 0);
        orientation.rotation = Quaternion.Euler(0, yrotation, 0);   
    }   

}
