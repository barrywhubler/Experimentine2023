using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdEnemyScript : MonoBehaviour
{
    [SerializeField] GameObject Wing;
    float wingFlapper = 1f;
    float wingFlipper = - 1f;
    //float wingFlipperer = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        wingFlapper = Time.deltaTime * wingFlipper + wingFlapper; 
        Wing.transform.localScale = new Vector3(1f, wingFlapper, 1f);
        if(-1 > wingFlapper || wingFlapper > 1)
        {
            wingFlapper = wingFlipper;
            wingFlipper *= -1;
        }
        Wing.transform.localScale = new Vector3(wingFlapper, 1f, 1f);
    }
}
