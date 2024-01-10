using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chompScript : MonoBehaviour
{
    //bool openingJaw = true;
    public GameObject rightMandible;
    public GameObject leftMandible;
    public float jawFloat = 0.0f;
    public float jawOpener = 3.0f;
    public float jawSpeed = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rightMandible.transform.localEulerAngles = new Vector3(0, jawFloat, 0);
        leftMandible.transform.localEulerAngles = new Vector3(0, -jawFloat, 0);
        jawFloat += jawOpener*Time.deltaTime*jawSpeed;
        if (jawFloat > 25.0f)
        {
            jawOpener = -1.0f;
        }else if (jawFloat < -25.0f)
        {
            jawOpener = 1.0f;
        }
    }
}
