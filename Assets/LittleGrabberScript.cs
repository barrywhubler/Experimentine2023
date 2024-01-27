using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleGrabberScript : MonoBehaviour
{
    [SerializeField] Rigidbody rocketSquirrelRB;
    [SerializeField] GameObject rocketSquirrelGO;
    [SerializeField] Transform grabberTransform;
    [SerializeField] bool canGrab;
    [SerializeField] public bool isGrabbing = false;
    [SerializeField] int collisionCounter = 0;
    [SerializeField] float grabInvincible = 0.1f;
    Vector3 differenceVector3;



    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
         if (other.gameObject.tag == "Obstacle")
        {
            //Debug.Log("Totally 11111111111111111111111111111111111111111111111");
            if (collisionCounter > 0)
            {
                collisionCounter++;
            }
            else
            {
                canGrab = true;
                collisionCounter = 1;
            }
        }
    }

        private void OnCollisionEnter(Collision collision)
    {
            Debug.Log("Collision!");

    }

    private void OnTriggerExit(Collider other)
    {
                if (other.gameObject.tag == "Obstacle")
        {
            //Debug.Log("Totally ?????????????????????????????????????????????");
            if (collisionCounter > 1)
            {
                collisionCounter--;
            }
            else
            {
                canGrab = false;
                collisionCounter = 0;
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {

    }
    
    private void ProcessGrab()
    {
        if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Totally 000000000000000000000000000000000000000000000");
            if (canGrab)
            {
                //grabberRB.constraints = RigidbodyConstraints.FreezePosition;
                differenceVector3 = transform.position - rocketSquirrelRB.position;
                isGrabbing = true;
                rocketSquirrelRB.useGravity = false;
                rocketSquirrelGO.GetComponent<RocketMovement>().grabFloat = 0;


            }
        }
        if (Input.GetKeyUp(KeyCode.Keypad2) || Input.GetKeyUp(KeyCode.Alpha2))
        {
            if (isGrabbing)
            {
                //grabberRB.constraints = RigidbodyConstraints.FreezePositionZ;
                isGrabbing = false;
                rocketSquirrelRB.useGravity = true;
                rocketSquirrelRB.AddRelativeForce(-500.0f, 0, 0);
                rocketSquirrelGO.GetComponent<RocketMovement>().grabFloat = 1;

            }
        }
        if (isGrabbing)
        {
            if (rocketSquirrelGO.GetComponent<CollisionHandler>().invincibleTime < grabInvincible)
            {
                rocketSquirrelGO.GetComponent<CollisionHandler>().invincibleTime = grabInvincible;

            }
        }
    }
    void RSControlTake()
    {
        //rocketSquirrelRB.position = Vector3.Lerp(rocketSquirrelRB.position, new Vector3(transform.position.x + 0.4f, transform.position.y - 0.0f, transform.position.z), Time.deltaTime * 4.0f);
        rocketSquirrelRB.position = Vector3.Lerp(rocketSquirrelRB.position, transform.position, Time.deltaTime * 8.0f);
        rocketSquirrelRB.rotation = Quaternion.Slerp(rocketSquirrelRB.rotation, transform.rotation, Time.deltaTime * 24.0f);

        //rocketSquirrelGO.transform.position = Vector3.Lerp(rocketSquirrelGO.transform.position, transform.position, Time.deltaTime * 4.0f);
        //rocketSquirrelGO.transform.rotation = Quaternion.Slerp(rocketSquirrelGO.transform.rotation, transform.rotation, Time.deltaTime * 6.0f);

    }

    // Update is called once per frame
    void Update()
    {
        if (isGrabbing)
        {
            RSControlTake();
        }
        else
        {
            GoToRocketSquirrel();
        }

        ProcessGrab();
        
    }

    private void GoToRocketSquirrel()
    {
        transform.position = grabberTransform.position;
        transform.rotation = grabberTransform.rotation;
    }
}
