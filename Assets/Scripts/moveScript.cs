using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveScript : MonoBehaviour
{
    public bool moveForward = true;
    public float speed = 2f;
    public float randomator;
    // Start is called before the first frame update
    void Start()
    {
        randomator = 1.0f + Random.value;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 26)
        {
            transform.position = new Vector3(transform.position.x-50.0f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -26)
        {
            transform.position = new Vector3(transform.position.x+50.0f, transform.position.y, transform.position.z);
        }

        if (moveForward)
        {
            transform.position = new Vector3(transform.position.x + speed * randomator * 0.01f, transform.position.y, transform.position.z );
        }
        else
        {
            transform.position = new Vector3(transform.position.x - speed *randomator* 0.01f, transform.position.y, transform.position.z);
        }
    }

}
