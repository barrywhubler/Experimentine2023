using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxRotateByMovement : MonoBehaviour
{
    float previousY;
    float previousX;
    public float rotationConversion = 0.0001f;
    //[SerializeField] Material mySkybox;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(Vector3.right * 35);
        previousY = transform.position.y;
        previousX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y != previousY)
        {
            float rotx = rotationConversion * (transform.position.y - previousY);
            transform.Rotate(Vector3.left * rotx);
            previousY = transform.position.y;
        }
        if (transform.position.x != previousX)
        {
            float roty = 2 * rotationConversion * (transform.position.x - previousX);
            transform.Rotate(Vector3.up * roty);
            previousX = transform.position.x;
        }


        //float positionY = transform.position.y - 150;
        
        //float positionX = transform.position.x;


        //transform.Rotate(Vector3.forward * Time.deltaTime * thrust);
        //transform.eulerAngles = new Vector3(Mathf.Abs(transform.position.y) * rotationConversion, Mathf.Abs(positionX) * rotationConversion, transform.rotation.z); 
    }
}
