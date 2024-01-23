using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    float oldAntSpeed;
    Color oldAntColor;
    GameObject powerAntGO;
    bool isPoweredUp = false;
    [SerializeField] float powerUpTime = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && isPoweredUp == false)
        {
            isPoweredUp = true;
            powerAntGO = collision.gameObject;
            oldAntColor = powerAntGO.GetComponent<AntColorScript>().antColor;
            oldAntSpeed = powerAntGO.GetComponent<moverScript>().antSpeed;
            powerAntGO.GetComponent<moverScript>().antSpeed *= 1.25f;
            powerAntGO.GetComponent<AntColorScript>().ChangeColor(Color.red);

            Invoke("revertSpeed", powerUpTime);
        }
    }

    private void revertSpeed()
    {
        powerAntGO.GetComponent<moverScript>().antSpeed = oldAntSpeed;
        powerAntGO.GetComponent<AntColorScript>().ChangeColor(oldAntColor);
        isPoweredUp = false;

    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 100);
    }
}
