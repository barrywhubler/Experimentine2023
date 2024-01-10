using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    int a = 1;
    float rForceX;
    float rForceY;
    float rForceZ;
    Rigidbody rb;
    [SerializeField] float mainThrust = 1000.0f;
    [SerializeField] float helpThrust = 80.0f;
    [SerializeField] float rotThrust = 150.0f;

    // Start is called before the first frame update
    void Start()
    {
        a++;
        rb = GetComponent<Rigidbody>();
    }

    void ProcessThrust()
    {
        rForceX = 1.0f * Time.deltaTime * helpThrust;
        rForceY = 1.0f * Time.deltaTime * mainThrust;
        rForceZ = 0.0f;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddRelativeForce(rForceX, rForceY, rForceZ);
            //Debug.Log("Up is pressed, Doki doki");
        }
        else if (Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(rForceX, rForceY, rForceZ);
            //Debug.Log("Up is pressed, Doki doki");
        }
    }

    void ProcessMovement()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            ApplyRotation(rotThrust);

            //Debug.Log("Left is pressed, Spin Spin");
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            ApplyRotation(-rotThrust);
            //Debug.Log("Up is pressed, Other Way, Other Way");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotThrust);            
            //Debug.Log("Up is pressed, The Other Way");
        }        
        else if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotThrust);
            //Debug.Log("Left is pressed, Spin");
        }

        
    }

    void ApplyRotation(float thrust)
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * thrust);
    }


    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessMovement();
    }
}
