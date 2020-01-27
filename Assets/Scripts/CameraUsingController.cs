using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUsingController : MonoBehaviour
{
    private float cameraInputX;
    private float cameraInputY;
    private float cameraSpeed = 5.0f;
    private float cameraBounds = 75.0f;
    private Vector3 cameraAngle;
    //-1 = too low, 1 = too high, 0 = within bounds
    private int outOfBounds = 0;

    [SerializeField] Transform playerBody = null;

    void Update()
    {
        //keep in camera bounds
        cameraAngle = transform.rotation.eulerAngles;
        if (cameraAngle.x < 360.0f-cameraBounds && cameraAngle.x > 180.0f)
        {
            //too high
            outOfBounds = 1;
        }
        else if (cameraAngle.x > cameraBounds && cameraAngle.x < 180.0f)
        {
            //too low
            outOfBounds = -1;
        }
        else
        {
            //in bounds
            outOfBounds = 0;
        }

        cameraInputX = Input.GetAxis("Stick X");
        cameraInputY = Input.GetAxis("Stick Y");

        //left+right relative to world
        playerBody.Rotate(new Vector3(0, cameraInputX, 0) * cameraSpeed, Space.World);

        //adjust camera input if out of bounds
        if(outOfBounds > 0 && cameraInputY < 0)
        {
            cameraInputY = 0;
        }
        else if (outOfBounds < 0 && cameraInputY > 0)
        {
            cameraInputY = 0;
        }
        //up is always up
        transform.Rotate(new Vector3(cameraInputY, 0, 0) * cameraSpeed / 2, Space.Self);
    }
}
