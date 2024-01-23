using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHelper : MonoBehaviour
{
    Camera myCamera;
    float helpX;
    float helpY;
    float helpZ;
    float helpAdd = 10.0f;
    //[SerializeField] float serHelpAddZ = 10.0f;
    //bool isZoomed = false;

    // Start is called before the first frame update
    void Start()
    {
        myCamera = Camera.main;
        //helpAddZ = serHelpAddZ;
    }

    void CameraInput()
    {
        if(Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Keypad0) || Input.GetKeyDown(KeyCode.Alpha0))
        {
            //if (isZoomed)
            //{

            //}
            //isZoomed = !isZoomed;
            helpAdd *= -1;
        }
    }
    void helpCamera()
    {
        helpX = transform.position.x + 20.0f - helpAdd;
        helpY = transform.position.y;
        helpZ = transform.position.z - 20.0f + helpAdd;

        myCamera.transform.position = new Vector3(helpX, helpY, helpZ);
    }
    // Update is called once per frame
    void Update()
    {
        CameraInput();
        helpCamera();
    }
}
