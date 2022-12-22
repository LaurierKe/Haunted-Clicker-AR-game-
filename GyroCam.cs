using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This script is to utilize the Gyro in a device to control a camera
*/
public class GyroCam : MonoBehaviour
{
    //Gyro 
    enum eGyroType { Mouse,Gyro};
    eGyroType CurrentGyroType;

    //Private values
    float xRotation;
    float yRotation;

    // Init Gyro
    void Start()
    {
        //Input.gyro.enabled = true;
        /*
        if(SystemInfo.operatingSystemFamily == OperatingSystemFamily.Other)
        {
            CurrentGyroType = eGyroType.Gyro;
        }
        else
        {
            CurrentGyroType = eGyroType.Mouse;
        }
        */
        CurrentGyroType = eGyroType.Mouse;
        xRotation = 0.0f;
        yRotation = 0.0f;
    }

    // Control camera
    void Update()
    {
        switch (CurrentGyroType)
        {
            case eGyroType.Mouse:
                yRotation += Input.GetAxis("Mouse X") * 3;
                xRotation -= Input.GetAxis("Mouse Y") * 3;
                xRotation = Mathf.Clamp(xRotation, -90, 90);
                transform.eulerAngles = new Vector3(xRotation, yRotation, 0.0f);
                break;
            case eGyroType.Gyro:
                transform.rotation = Input.gyro.attitude;
                transform.Rotate(0f, 0f, 180f, Space.Self);
                transform.Rotate(90f, 180f, 0f, Space.World);
                break;
        }
    }
    /*
    private void OnGUI()
    {
        if(GUI.Button(new Rect(Screen.width/2 + 10, 10, 150, 50),"GYRO" + CurrentGyroType))
        {
            switch (CurrentGyroType)
            {
                case eGyroType.Mouse:
                    CurrentGyroType = eGyroType.Gyro;
                    break;
                case eGyroType.Gyro:
                    CurrentGyroType = eGyroType.Mouse;
                    break;
            }
        }
    }
    */
}
