using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Camera : MonoBehaviour
{
    public float minimumX = -60f;
    public float maximumX = 60f;
    public float turnSpeed = 15f;
    public Camera cam;
    float rotX = 0f;
    float rotY = 0f;
  
    void CamLook ()
    {
    //Input
    rotX += Input.GetAxis("Mouse Y") * turnSpeed;
    rotY += Input.GetAxis("Mouse X") * turnSpeed;

    //calculations
    rotX = Mathf.Clamp(rotX,minimumX,maximumX);

    //Execution
    transform.localEulerAngles = new Vector3 (0,rotY,0);
    cam.transform.localEulerAngles = new Vector3 (-rotX,0,0);
    }
    void Update()
    {
        CamLook();
    }
     // Start is called before the first frame update
    void Start()
    {
    Cursor.visible = false;
    Cursor.lockState = CursorLockMode.Locked;
    }
}

