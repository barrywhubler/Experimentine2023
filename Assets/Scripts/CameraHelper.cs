using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHelper : MonoBehaviour
{
    [SerializeField] Camera myCamera;
    float helpX;
    float helpY;
    float helpZ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void helpCamera()
    {
        helpX = transform.position.x;
        helpY = transform.position.y;
        helpZ = transform.position.z - 10;

        myCamera.transform.position = new Vector3(helpX, helpY, helpZ);
    }
    // Update is called once per frame
    void Update()
    {
        helpCamera();
    }
}
