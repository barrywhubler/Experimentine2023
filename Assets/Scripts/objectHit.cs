using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectHit : MonoBehaviour
{
    private Color myColor;
    private float oneSecond;
    bool isHit = false;
    // Start is called before the first frame update
    void Start()
    {
        myColor = GetComponent<MeshRenderer>().material.color;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log(collision.gameObject.name + " bumped into the " + this.name + ", dummy.");
            GetComponent<MeshRenderer>().material.color = Color.magenta;
            oneSecond = 1.0f;
            isHit = true;
            //gameObject.tag = "Hit";
        }
        
    }

    void ChangeBack()
    {
        //yield return new WaitForSeconds(1);
        
        GetComponent<MeshRenderer>().material.color = myColor;
    }
    // Update is called once per frame
    void Update()
    {
        if (isHit)
        {
            if (oneSecond > 0)
            {
                oneSecond -= Time.deltaTime;
            }
            else
            {
                isHit = false;
                ChangeBack();
            }
        }
    }
}
