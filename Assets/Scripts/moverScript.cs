using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverScript : MonoBehaviour
{
    [SerializeField] float xValue = 0.0f;
    [SerializeField] float yValue = 0.0f;
    [SerializeField] float zValue = 0.0f;

    [SerializeField] float xRot = 0.0f;
    [SerializeField] float yRot = 0.0f;
    [SerializeField] float zRot = 0.0f;

    [SerializeField] GameObject[] onLegs;
    [SerializeField] GameObject[] offLegs;
    private float legFloat = 0;
    [SerializeField] public float antSpeed = 20;
    //[SerializeField] bool powerUp = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void legAction()
    {
        legFloat += Input.GetAxis("Vertical")*Time.deltaTime*1000;

        if (legFloat > 360.0f)
        {
            legFloat -= 360.0f;
        }else if(legFloat < 0)
        {
            legFloat += 360.0f;
        }

        foreach (GameObject nLeg in onLegs)
        {
            nLeg.transform.localEulerAngles = new Vector3(legFloat, transform.rotation.y, transform.rotation.z);
        }
        foreach (GameObject fLeg in offLegs)
        {
            fLeg.transform.localEulerAngles = new Vector3(legFloat - 180.0f, transform.rotation.y, transform.rotation.z);
        }

        //transform.localEulerAngles = new Vector3(legFloat, transform.rotation.y, transform.rotation.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        transform.Translate(xValue, yValue, -Input.GetAxis("Vertical"));
        //if(collision.gameObject.name == "PowerUpCapsule")
        //{
        //    if(powerUp == false) { 
        //        powerUp = true;
        //        GetComponent<MeshRenderer>().material.color = Color.yellow;
        //        antSpeed *= 2.0f;
        //        //collision.gameObject.GetComponent(enabled) = false;
        //    }
        //}
    }
    void PlayerMovement()
    {
        float yRot = Input.GetAxis("Horizontal")*500*Time.deltaTime;
        float zValue = Input.GetAxis("Vertical")*antSpeed*Time.deltaTime;
        transform.Translate(xValue, yValue, zValue);
        transform.Rotate(xRot, yRot, zRot);
        legAction();
    }


    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }
}
