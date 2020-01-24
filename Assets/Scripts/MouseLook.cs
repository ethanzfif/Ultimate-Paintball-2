using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    [SerializeField] Transform playerBody = null;

    float xRotation = 0f;
    float _mouseX;
    float _mouseY;

    void Update()
    {
        if (Cursor.lockState != CursorLockMode.Locked) { return; }

        //checks if mouse is used to allow for right stick inputs
        if (!(Input.GetAxis("Mouse X") == 0.0f && Input.GetAxis("Mouse X") == 0.0f))
        {
            _mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

            _mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;


            xRotation -= _mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            playerBody.Rotate(Vector3.up * _mouseX);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        }
    }
}
