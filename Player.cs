using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
This is a player script to move around the field
*/

[RequireComponent(CharacterController.cs)]
public class Player : MonoBehaviour
{
    //Player values
    [SerializeField] float moveSpeed = 10.0f;
    [SerializeField] float rotateSpeed = 90.0f;
    [SerializeField] float jumpImpulse = 10.0f;
    [SerializeField] float gravity = -9.81f;

    //Private values
    Vector3 moveVector;
    float Yvelocity;

    CharacterController playerController;

    // Init values
    void Start()
    {
        playerController = GetComponent<CharacterController>();
        Yvelocity = 0.0f;
    }

    // Move player
    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime, 0);
        moveVector = new Vector3(0, 0, Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);

        if (playerController.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                Yvelocity = jumpImpulse;
                Debug.Log("Jumped");
            }
        }
        else
        {
            Yvelocity += gravity * Time.deltaTime;
        }

        moveVector.y = Yvelocity * Time.deltaTime;

        moveVector = transform.rotation * moveVector;
        playerController.Move(moveVector);
    }
}
