using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUsingController : MonoBehaviour
{
    private float cameraInputX;
    private float cameraInputY;
    private float cameraSpeed = 5.0f;

    [SerializeField] Transform playerBody = null;

    void Update()
    {
        cameraInputX = Input.GetAxis("Stick X");
        cameraInputY = Input.GetAxis("Stick Y");

        //cameraInputZ = Mathf.Clamp(cameraInputZ, -90, 90);

        //left+right relative to world
        playerBody.Rotate(new Vector3(0, cameraInputX, 0) * cameraSpeed, Space.World);
        //up is always up
        transform.Rotate(new Vector3(cameraInputY, 0, 0) * cameraSpeed/2, Space.Self);
    }
}
