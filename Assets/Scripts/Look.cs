using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    
    private float xRotation = 0f;
    
    void Update()
    {
        var mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        var mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
        //vertical rotation
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        
        //horizontal rotation
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
