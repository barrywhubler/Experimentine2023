using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{

    [SerializeField] TMP_Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        timerText.SetText(Time.time + "");
    }

    // Update is called once per frame
    void Update()
    {
        timerText.SetText(Time.time + "");
    }
}
