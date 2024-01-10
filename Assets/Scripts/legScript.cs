using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class legScript : MonoBehaviour
{
    public bool isOffLeg = false;
    private float legFloat = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (isOffLeg)
        {
            legFloat = legFloat - 180.0f;
            //transform.rotation = new Quaternion(transform.rotation.x - 180.0f, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        }
    }

    // Update is called once per frame
    void Update()
    {
        legFloat += 1.0f;

        if (legFloat > 360.0f)
        {
            legFloat = -360.0f;
        }
        transform.localEulerAngles = new Vector3(legFloat, transform.rotation.y, transform.rotation.z);
    }
}
