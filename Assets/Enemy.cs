using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField] Material enemyMaterial;
    [SerializeField] string changeColorString = "red";
    [SerializeField] float colorR = 0;
    [SerializeField] float colorG = 0;
    [SerializeField] float colorB = 0;
    [SerializeField] bool isChangeColor = false;


    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector = new Vector3(1f,1f,1f);
    [SerializeField] float oscillationX = 0f;
    [SerializeField] float oscillationY = 0f;
    [SerializeField] float oscillationZ = 0f;
    [SerializeField] [Range(-1, 1)] float movementFactor;
    [SerializeField] Vector3 vectorFactor;
    [SerializeField] float maxOscillation = 10f;
    [SerializeField] float oscillationSpeedX = 0.5f;
    [SerializeField] float oscillationSpeedY = 0.5f;
    [SerializeField] float oscillationSpeedZ = 0.5f;
    float period = 2f;
    
    [SerializeField] bool isOscillatingX = false;
    [SerializeField] bool isOscillatingY = false;
    [SerializeField] bool isOscillatingZ = false;
    [SerializeField] bool isSimpleOscillating = false;
    [SerializeField] bool isFullCircle = false;
    [SerializeField] bool isOcilRotate;
    [SerializeField] bool isRightR = false;
    [SerializeField] bool isLeftR = false;
    [SerializeField] bool isFaceLeft = false;
    float rotator = 0f;
    float rotatorSpeed = 5f;


    Vector3 offset;

    [SerializeField] GameObject birdWings;
    float wingScale;
    bool isWings = false;






// Start is called before the first frame update
void Start()
    {
        if (enemyMaterial != null)
        {
            enemyMaterial.color = Color.white;
        }
        startingPosition = transform.position;
        if (birdWings != null)
        {
            wingScale = transform.localScale.y / 3;
            isWings = true;
        }

    }

    void ColorChanger(string colorString)
    {
        switch(colorString){
            case "red":
                ChannelChanger(-0.005f, colorB, 2);
                if(colorB == 0)
                {
                    changeColorString = "yellow";
                }
                break;
            case "yellow":
                ChannelChanger(0.005f, colorG, 1);
                if (colorG == 1f)
                {
                    changeColorString = "green";
                }
                break;
            case "green":
                ChannelChanger(-0.005f, colorR, 0);
                if (colorR == 0)
                {
                    changeColorString = "turquoise";
                }
                break;
            case "turquoise":
                ChannelChanger(0.005f, colorB, 2);
                if (colorB == 1f)
                {
                    changeColorString = "blue";
                }
                break;
            case "blue":
                ChannelChanger(-0.005f, colorG, 1);
                if (colorG == 0)
                {
                    changeColorString = "violet";
                }
                break;
            case "violet":
                ChannelChanger(0.005f, colorR, 0);
                if (colorR == 1f)
                {
                    changeColorString = "red";
                }
                break;
            default:
                ChannelChanger(0.005f, colorR, 0);
                if (colorR == 1f)
                {
                    changeColorString = "yellow";
                }
                break;


        }
    }

    void ChannelChanger( float changer, float channel, int inCase)
    {
        Debug.Log(channel + " " + changer);
        channel += changer;
        if (channel < 0)
        {
            channel = 0;
        }else if(channel > 1)
        {
            channel = 1;
        }
        if (inCase == 0)
        {
            colorR = channel;
        }
        else if (inCase == 1)
        {
            colorG = channel;
        }
        else if (inCase == 2)
        {
            colorB = channel;
        }
        enemyMaterial.color =  new Color(colorR, colorG, colorB, 1);
        //Debug.Log("" + enemyMaterial.color);
    }

    void Oscillator()
    {
        if (isFullCircle)
        {
            SinOscillator();
        }else if (isSimpleOscillating)
        {
            SimpleOscillator();
        }
        
        
    }
    void SimpleOscillator()
    {
        float floatX = Mathf.Abs(startingPosition.x - transform.position.x);
        float floatY = Mathf.Abs(startingPosition.y - transform.position.y);
        if (floatX > maxOscillation || floatY > maxOscillation)
        {
            movementFactor *= -1;
        }
        OffsetTheVector();
        transform.Translate(offset); 
        
    }
    void SinOscillator()
    { 
        if(period <= Mathf.Epsilon) { return; }

     
        //float cyclesX = Time.time / period * oscillationSpeedX;
        //float cyclesY = Time.time / period * oscillationSpeedY;
        //float cyclesZ = Time.time / period * oscillationSpeedZ;
        float rawSinWaveX;
        float rawSinWaveY;
        float rawSinWaveZ;
        const float tau = Mathf.PI * 2;
        if (isOscillatingX)
        {
            float cyclesX = Time.time / period * oscillationSpeedX;
            rawSinWaveX = Mathf.Sin(cyclesX * tau);
        }
        else
        {
            rawSinWaveX = 0f;
        }
        if (isOscillatingY)
        {
            float cyclesY = Time.time / period * oscillationSpeedY;
            rawSinWaveY = Mathf.Sin(cyclesY * tau);
        }
        else
        {
            rawSinWaveY = 0f;
        }
        if (isOscillatingZ)
        {
            float cyclesZ = Time.time / period * oscillationSpeedZ;
            rawSinWaveZ = Mathf.Sin(cyclesZ * tau);
        }
        else
        {
           rawSinWaveZ = 0f;
        }
        vectorFactor = new Vector3(rawSinWaveX + 1f / 2f, rawSinWaveY + 1f / 2f, rawSinWaveZ + 1f / 2f);
        OffsetTheVector();
        transform.position = startingPosition + offset;
        //Debug.Log("00000000000000000000000000000000000000000000000000000000000000?" + rawSinWaveY);
        if (isWings)
        {
            float negSin = 1 - rawSinWaveY;
            birdWings.transform.localScale = new Vector3(wingScale * negSin - wingScale  , birdWings.transform.localScale.y, birdWings.transform.localScale.z);
        }
        
        if (isOcilRotate)
        {
            
            if(rawSinWaveX > 0.9f && !isFaceLeft)
            {
                if (!isRightR)
                {
                    isRightR = true;
                }

            }
            else if(rawSinWaveX < -0.9f && isFaceLeft)
            {
                if (!isLeftR)
                {
                    isLeftR = true;
                }

            }

        }
    }

    void OscilatorRotate()
    {
        if (isRightR)
        {
            if (rotator < 180f)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + rotatorSpeed * oscillationSpeedX, transform.eulerAngles.z);
                rotator += rotatorSpeed * oscillationSpeedX;
            }
            else
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180f, transform.eulerAngles.z);
                rotator = 180f;
                isRightR = false;
                isFaceLeft = true;
            }
        }else if (isLeftR)
        {
            if (rotator >.05f)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y - rotatorSpeed * oscillationSpeedX, transform.eulerAngles.z);
                rotator -= rotatorSpeed * oscillationSpeedX;
            }
            else
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0f, transform.eulerAngles.z);
                rotator = 0f;
                isLeftR = false;
                isFaceLeft = false;
            }
        }
    }

    void OffsetTheVector()
    {
        offset = new Vector3( movementVector.x * vectorFactor.x, movementVector.y * vectorFactor.y, movementVector.z * vectorFactor.z);


    }
    // Update is called once per frame
    void Update()
    {
        if (isOscillatingX || isOscillatingY || isOscillatingZ)
        {
            Oscillator();
        }
        if(isRightR || isLeftR)
        {
            OscilatorRotate();
        }
        if (enemyMaterial != null)
        {
            ColorChanger(changeColorString);
        }
        //Debug.Log(changeColorString + colorR + colorG +colorB);
    }
}
