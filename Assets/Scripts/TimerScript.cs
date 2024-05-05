using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public static float timeValue = 0;
    public static float delayValue = 0;
    public TMP_Text timerText;
    private PointScript point;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!HeartScript.end)
        {
            if (!PointScript.win)
            {
                {
                    timeValue += Time.deltaTime;
                    displayTimeValue(timeValue);
                }
            }
        }
    }

    void displayTimeValue(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}