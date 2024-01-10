using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerScript : MonoBehaviour
{
    [SerializeField] float rotX = 0;
    [SerializeField] float rotY = 0;
    [SerializeField] float rotZ = 0;
    [SerializeField] float countDown = 2.0f;
    float counter = 2.0f;
    float rotationCount = 0.0f;
    [SerializeField] float countProbability = 20.0f;
    bool isSpin = true;
    [SerializeField] float spinSpeed;
    // Start is called before the first frame update
    void Start()
    {
        spinSpeed = Random.value;
    }

    // Update is called once per frame
    void Update()
    {
        if(isSpin)
        {
            rotY = spinSpeed * Time.deltaTime * 360;
            rotationCount += rotY;
            if (rotationCount > 360)
            {
                rotationCount = 0;
                isSpin = false;
            }
            transform.Rotate(rotX,rotY,rotZ);
        }
        else {
            counter -= Time.deltaTime;
            if (counter <= 0)
            {
                counter = countDown;
                if (Random.value* 100.0f <= 20.0f)
                {
                    spinSpeed = Random.value;
                    isSpin = true;
                }
                
            }
        }
    }
}
