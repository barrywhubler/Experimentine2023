
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///using UnityEngine.UI;
using TMPro;

public class StageManagerScript : MonoBehaviour
{
    [SerializeField] TMP_Text nutsText;
    [SerializeField] TMP_Text stageText;
    [SerializeField] GameObject RSGO;
    int nutCounter = 0;
    float tCounter = 0.0f;

    //testing only
    //[SerializeField] TMP_Text invincibility;

    Component nutsComp;
    // Start is called before the first frame update
    void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name; 
        stageText.text = sceneName;
        
        if (RSGO.GetComponent<NutScript>() != null){
            //nutsComp = RSGO.GetComponent<NutScript>();
        }
        else
        {
            nutsText.text = "Oops!";
        }

        
        
    }

    // Update is called once per frame
    void Update()
    {
        //stageText.text = Input.acceleration + "";
        tCounter += Time.deltaTime;
        if (tCounter > 0.025f)
        {
            tCounter = 0.0f;
            if (nutCounter < RSGO.GetComponent<NutScript>().nutCount)
            {
                nutCounter++;
                nutsText.text = "" + nutCounter;
            }
            else if (nutCounter > RSGO.GetComponent<NutScript>().nutCount)
            {
                nutCounter--;
                nutsText.text = "" + nutCounter;
            }
        }
        //Testing only
        //invincibility.text = "" + RSGO.GetComponent<CollisionHandler>().invincibleTime;
    }
}
