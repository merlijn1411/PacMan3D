using System;
using UnityEngine;

public class PlayerCam: MonoBehaviour
{
    [SerializeField] private float sensX;
    [SerializeField] private float sensY;

    [SerializeField] private Transform orientation;

    [SerializeField] private float xrotation;
    [SerializeField] private float yrotation;

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
        
        transform.rotation = Quaternion.Euler(xrotation, yrotation, 0);
        orientation.rotation = Quaternion.Euler(0, yrotation, 0);   
    }   

}
