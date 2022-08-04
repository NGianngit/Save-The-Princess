using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CameraFollower : MonoBehaviour
{
    public Vector3 camPivot = Vector3.zero;
    public Vector3 camRotation = new Vector3(45, 35, 0);

    public float camSpeed = 5.0f;
    public float camDistance = 5.0f;
    public Vector3 camOffset;

    public GameObject swordsMan;
    

    private Vector3 target;

    private Vector3 newPos;
    private Camera mainCamera;



    private void Start()
    {
        mainCamera = GetComponent<Camera>();
    }
    private void Update()
    {
        //zooms the camera in when the dialogue is running.

        //moves the camera to the target position.
        target = (swordsMan.transform.position);
        camPivot = target;
        newPos = camPivot;

        //sets the rotation of the camera.
        transform.eulerAngles = camRotation;


        if (mainCamera.orthographic)
        {
            newPos += -transform.forward * camDistance * 4F;
            newPos += camOffset;
            mainCamera.orthographicSize = camDistance;
        }

        //moves the camera to the new position which takes in a offset as well
        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * camSpeed);

    }
}