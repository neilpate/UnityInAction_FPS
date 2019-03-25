using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX,
        MouseY
    }

    public RotationAxes axes = RotationAxes.MouseXAndY;

    public float SensitivityYaw = 9.0f;
    public float SensitivityPitch = 9.0f;

    public float MinimumPitch = -45;
    public float MaximumPitch = 45;
    float pitch = 0;
    float yaw = 0;

    // Start is called before the first frame update
    void Start()
    {
        var body = GetComponent<Rigidbody>();
        if (body != null)
        {
            body.freezeRotation = true;
        }
        
        Cursor.lockState = CursorLockMode.Locked;

        Application.targetFrameRate = 30;
    }

    //This will be used to rotate the player around the Y axis
    Vector3 CalcAnglesForXMovement()
    {
        return new Vector3(0, Input.GetAxis("Mouse X") * SensitivityYaw, 0);
    }

    //This will be used to tilt the camera
    Vector3 CalcAnglesForYMovement()
    {
        pitch += Input.GetAxis("Mouse Y") * SensitivityPitch;
        pitch = Mathf.Clamp(pitch, MinimumPitch, MaximumPitch);
        float rotationY = transform.localEulerAngles.y;
        return new Vector3(pitch, 0, 0);
    }

    //Not currently used
    Vector3 CalcAnglesForXYMovement()
    {
        pitch += Input.GetAxis("Mouse Y") * SensitivityPitch;
        pitch = Mathf.Clamp(pitch, MinimumPitch, MaximumPitch);
        yaw += Input.GetAxis("Mouse X") * SensitivityYaw;
        return new Vector3(pitch, yaw, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.None;


        switch (axes)
        {
            case RotationAxes.MouseX:
                transform.Rotate(CalcAnglesForXMovement());
                break;

            case RotationAxes.MouseY:
                transform.localEulerAngles = CalcAnglesForYMovement();
                break;

            case RotationAxes.MouseXAndY:
                 transform.localEulerAngles = CalcAnglesForXYMovement();
                break;
            default:
                break;
        }




    }
}
