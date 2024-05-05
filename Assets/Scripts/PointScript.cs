using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointScript : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text pointText;
    public static bool win = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (win)
        {
            int total = 6000 - ((int)TimerScript.timeValue * 10) ;
            string output = string.Format("{0:D4}", total);
            pointText.text = output;
        }
        else
        {
            int total = 10;
            string outputValue = string.Format("{0:D4}",total);
            pointText.text = outputValue;
        }
    }
}
