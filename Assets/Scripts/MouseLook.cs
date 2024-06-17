using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MouseLook : NetworkBehaviour
{
    public float mouseSensitivity;
    [SerializeField]private Transform Controller;
    float xRotation = 0f;

    void Start(){
        if (!isLocalPlayer) {
            this.gameObject.SetActive(false);
        }
        Cursor.lockState = CursorLockMode.Locked;
        mouseSensitivity = 400f;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Escape)){
            Cursor.lockState = CursorLockMode.None;
        } else if (Input.GetKey(KeyCode.Space)) {
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (!isLocalPlayer) {
            return;
        }
            
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        Controller.Rotate(Vector3.up * mouseX);
    
    }
}
