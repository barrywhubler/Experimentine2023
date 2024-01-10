using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerMakerScript : MonoBehaviour
{
    [SerializeField] GameObject spinBlock;
    [SerializeField] float spinTime = 3.0f;
    [SerializeField] float spinTimer;
    // Start is called before the first frame update
    void Start()
    {

        //timerText.SetText(Time.time + "");
        spinTimer = spinTime;
    }

    // Update is called once per frame
    void Update()
    {
        //timerText.SetText(Time.time +"");
        spinTimer -= Time.deltaTime;
        if (spinTimer < 0)
        {
            spinTimer = spinTime;
            Instantiate(spinBlock, new Vector3(Random.Range(-23.0f, 23.0f), 1.5f, Random.Range(-23.0f, 23.0f)), Quaternion.Euler(0.0f, 0.0f, 0.0f));
        }

    }
}
