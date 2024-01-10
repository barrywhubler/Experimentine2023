using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;

public class Dropper : MonoBehaviour
{
    //[SerializeField] TMP_Text timerText;
    [SerializeField]GameObject dropBlock;
    public float dropTime = 3.0f;
    public float dropTimer;
    // Start is called before the first frame update
    void Start()
    {
        
        //timerText.SetText( Time.time + "");
        dropTimer = dropTime;
    }

    // Update is called once per frame
    void Update()
    {
        //timerText.SetText(Time.time +"");
        dropTimer -= Time.deltaTime;
        if (dropTimer < 0)
        {
            dropTimer = dropTime;
            Instantiate(dropBlock, new Vector3(Random.Range(-23.0f,23.0f),10.0f, Random.Range(-23.0f, 23.0f)), Quaternion.Euler(0.0f,0.0f,0.0f));
        }

    }
}
