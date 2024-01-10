using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSlingingScript : MonoBehaviour
{
    [SerializeField] GameObject ballBlock;
    [SerializeField] float ballTime = 3.0f;
    [SerializeField] float ballTimer;
    // Start is called before the first frame update
    void Start()
    {

        //timerText.SetText(Time.time + "");
        ballTimer = ballTime;
    }

    // Update is called once per frame
    void Update()
    {
        //timerText.SetText(Time.time +"");
        ballTimer -= Time.deltaTime;
        if (ballTimer < 0)
        {
            ballTimer = ballTime;
            if (Random.value > 0.5f)
            {
                Instantiate(ballBlock, new Vector3(-45.0f, 40.0f, Random.Range(-23.0f, 23.0f)), Quaternion.Euler(0.0f, 0.0f, 0.0f));
            }
            else
            {
                Instantiate(ballBlock, new Vector3(45.0f, 40.0f, Random.Range(-23.0f, 23.0f)), Quaternion.Euler(0.0f, 0.0f, 0.0f));
            }
            
        }

    }
}
