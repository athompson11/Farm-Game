using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontrols : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ; //Pass
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 cameraMoveDir = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W)) {
            cameraMoveDir.z = +1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            cameraMoveDir.z = -1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            cameraMoveDir.x = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            cameraMoveDir.x = +1f;
        }

        float rotation = 0f;

        if (Input.GetKey(KeyCode.Q))
        {
            rotation = +2f;
        }

        if (Input.GetKey(KeyCode.E))
        {
            rotation = -2f;
        }

        int scrollArea = 20; //px

        if (Input.mousePosition.x <= scrollArea)
        {
            cameraMoveDir.x = -1f;
        }

        if (Input.mousePosition.y <= scrollArea)
        {
            cameraMoveDir.z = -1f;
        }

        if (Input.mousePosition.x >= Screen.width - scrollArea)
        {
            cameraMoveDir.x = +1f;
        }

        if (Input.mousePosition.y >= Screen.height - scrollArea)
        {
            cameraMoveDir.z = +1f;
        }

        Vector3 moveWithRotation = transform.forward * cameraMoveDir.z + transform.right * cameraMoveDir.x; //Take global directions into account to (possibly) allow for rotation)

        float movespeed = 30f;//Slow enough to cut down on lurch

        transform.position += moveWithRotation * movespeed * Time.deltaTime; //Move relative to framerate so that movement isn't choppy

        if (rotation != 0f)
        {
            Vector3 rotationVector = new Vector3(0, rotation * movespeed * Time.deltaTime, 0); //Pivot around Y (up axis)
            transform.eulerAngles += rotationVector;
        }
    }
}
