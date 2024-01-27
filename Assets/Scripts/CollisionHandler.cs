using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class CollisionHandler : MonoBehaviour
{
    bool isPlayerCrashed = false;
    bool isLevelCompleted = false;

    [SerializeField] AudioClip boom;
    [SerializeField] AudioClip completetionDing;
    [SerializeField] AudioClip squirrelNom;
    [SerializeField]float countdownToReload = 3.0f;
    [SerializeField] float countdownToNext = 1.0f;
    [SerializeField] float invincibleTimer = 1f;
    public float invincibleTime = 0.5f;
    [SerializeField] ParticleSystem SuccessRSParticle;
    [SerializeField] ParticleSystem FailureRSParticle;
    GameObject findGrabber;

    [SerializeField] AudioSource collisionAudioSource;

    [SerializeField] bool debugMode = false;
    bool collisionDisabled = false;
    bool isIsGrabbing = false;
    //int A = 0;
    //int B = 1;
    //string collidedOn ="";

    private void Start()
    {
        //collisionAudioSource = GetComponent<AudioSource>();
        findGrabber = GameObject.FindWithTag("Grabber");
    }

    private void OnCollisionEnter(Collision collision)
    {
        //collidedOn = collision.gameObject.tag;
        //switch (collidedOn) {
        if (!collisionDisabled)
        {
            switch (collision.gameObject.tag)
            {
                case "Friendly":
                    //Debug.Log(collision.gameObject.tag);
                    break;
                case "Finish":

                    //Debug.Log(collision.gameObject.tag);
                    LevelCompleted();
                    break;
                case "Fuel":
                    //Debug.Log(collision.gameObject.tag);
                    GetAcorn(collision.gameObject);
                    break;
                default:
                    //Debug.Log("Nuts!!!");
                    TouchObstacle();

                    break;
            }
        }

    
    }


    private void LevelCompleted()
    {
        isLevelCompleted = true;
        collisionAudioSource.PlayOneShot(completetionDing);
        SuccessRSParticle.Play();
        collisionDisabled = true;
        

    }
    void GetAcorn(GameObject acorn)
    {
        acorn.GetComponent<AcornScript>().EatAcorn();
        GetComponent<NutScript>().nutCount += 50;
        collisionAudioSource.PlayOneShot(squirrelNom);
    }
    void TouchObstacle()
    {

        
        if(findGrabber != null)
        {
            isIsGrabbing = findGrabber.GetComponent<LittleGrabberScript>().isGrabbing;
            if (!isIsGrabbing && invincibleTime <= 0 && !collisionDisabled)
            {
                BadTouch();
            }
        }
        else
        {
            BadTouch();
        }
    }
    private void BadTouch()
    {

        collisionAudioSource.PlayOneShot(boom);
        FailureRSParticle.Play();
        if(GetComponent<NutScript>().nutCount <= 0)
        {
            LevelFailed();
        }
        else
        {
            GetComponent<NutScript>().nutCount -= 10;
            invincibleTime = invincibleTimer;
        }
    }

    private void LevelFailed()
    {

        isPlayerCrashed = true;

    }

    

    private void Update()
    {
        IfPlayerCrashed();
        IfLevelCompleted();

        RespondToDebugInput();
        Invincibility();
        
    }

    void Invincibility()
    {
        if(invincibleTime > 0)
        {
            invincibleTime -= Time.deltaTime;
        }
    }

    private void IfPlayerCrashed()
    {
        if (isPlayerCrashed)
        {
            //GetComponent<RocketMovement>().enabled = false;
            countdownToReload -= Time.deltaTime;
            if (countdownToReload < 0)
            {
                ReloadScene();
            }
        }
    }

    private static void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void IfLevelCompleted()
    {
        if (isLevelCompleted)
        {
            countdownToNext -= Time.deltaTime;
            if (countdownToNext < 0)
            {
                LoadNextScene();
            }
        }
    }
    void LoadNextScene()
    {

        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        //Debug.Log(nextSceneIndex + " !!!!!!!!!!!!!!!!!!!!!! " + SceneManager.sceneCount);

        if (nextSceneIndex > 9) {
                nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);

    }
    private void RespondToDebugInput()
    {
        if (debugMode)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                LoadNextScene();
            }
            else if (Input.GetKeyDown(KeyCode.O))
            {
                ReloadScene();
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                collisionDisabled = !collisionDisabled;

            }
        }
    }
}
