using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
This script will rotate around based on 
Give values
*/
public class Orbit : MonoBehaviour
{
    [Header("Rotate values")]
    [SerializeField] float rotateSpeed;
    [SerializeField] float radius;

    //Private values
    private float timeCounter;
    private float x;
    private float z;

    // Init timeCounter
    void Start()
    {
        timeCounter = 0f;
    }

    // Rotate this object
    void Update()
    {
        timeCounter += Time.deltaTime * rotateSpeed;
        x = Mathf.Cos(timeCounter) * radius;
        z = Mathf.Sin(timeCounter) * radius;
        transform.position = new Vector3(x, gameObject.transform.position.y, z);

    }
}
