using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    float rForceX;
    float rForceY;
    float rForceZ;
    Rigidbody rb;

    [SerializeField] float mainThrust = 1000.0f;
    [SerializeField] float helpThrust = 80.0f;
    [SerializeField] float rotThrust = 150.0f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem BoosterRSParticle;
    [SerializeField] int boosterParticleCount = 1000;
    ParticleSystem.EmissionModule myRSEmissionModule;
    public float grabFloat = 1.0f;

    [SerializeField] AudioSource movementAudioSource;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        //audioSource = GetComponent<AudioSource>();
        //myRSEmissionModule = BoosterRSParticle.emission;
        myRSEmissionModule = BoosterRSParticle.emission;
        //Debug.Log("" + myRSEmissionModule);
        myRSEmissionModule.rateOverTime = 0;
        //BoosterRSParticle.GetComponent<em>
    }

    void ProcessThrust()
    {

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            StartThrusting();

        }
        else
        {
            StopThrusting();
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            movementAudioSource.Stop();
        }
    }


    private void StartThrusting()
    {
        rForceX = 1.0f * Time.deltaTime * helpThrust * grabFloat;
        rForceY = 1.0f * Time.deltaTime * mainThrust * grabFloat;
        rForceZ = 0.0f;
        rb.AddRelativeForce(rForceX, rForceY, rForceZ);
        if (!movementAudioSource.isPlaying)
        {
            movementAudioSource.PlayOneShot(mainEngine);
        }
        if (!BoosterRSParticle.isPlaying)
        {
            BoosterRSParticle.Play();
        }
        myRSEmissionModule.rateOverTime = boosterParticleCount;
    }

    private void StopThrusting()
    {
        //BoosterRSParticle.Pause();
        myRSEmissionModule.rateOverTime = 0;
        //Debug.Log("BOOOOOOOOOOOOOOOOOOOOOOOOOOO");
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
