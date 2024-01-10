using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCherScript : MonoBehaviour
{
    [SerializeField] TMP_Text scorerText;
    public int basheds = 0;
    // Start is called before the first frame update
    void Start()
    {
        scorerText.SetText(basheds + "");
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        Debug.Log("You smashed into " + collision.gameObject.name + "!!!");
        if (collision.gameObject.tag != "Hit")
        {
            basheds++;
            scorerText.SetText(basheds + "");
            //Debug.Log("You recklessly damaged " + basheds + " things!!!");
            collision.gameObject.tag = "Hit";
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
