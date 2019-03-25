using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{

    public float Speed = 0.1f;
    public bool Walking = false;

    public float Gravity = -9.81f;

    CharacterController characterController;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * Speed;
        float deltaZ = 0;

        if (Input.GetMouseButton(1))
            Walking = true;
        else
            Walking = false;

        if (Walking)
            deltaZ = Speed;
        else
            deltaZ = 0;

        Vector3 movement = new Vector3(deltaX, Gravity, deltaZ);
        movement = Vector3.ClampMagnitude(movement, Speed);
      //  movement.y = Gravity;
        movement *= Time.deltaTime;

        movement = transform.TransformDirection(movement);

        characterController.Move(movement);


    }
}
