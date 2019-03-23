using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{
    
    
    public float totalTime;
    public GameObject timerUI;
    public GameObject p1scoreUI;
    public GameObject p2scoreUI;
    public GameObject map;
    public GameObject p1;
    public GameObject p2;

    public bool timerisout= false;
    private void FixedUpdate()
    {
        if (timerisout == false)
        {
            totalTime -= Time.deltaTime;
            UpdateLevelTimer(totalTime);
             if (totalTime < 1)
                    {
                timerisout = true;
                    }
        }
        else { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); }
        
    }

    public void UpdateLevelTimer(float totalSeconds)
    {
        int minutes = Mathf.FloorToInt(totalSeconds / 60f);
        int seconds = Mathf.RoundToInt(totalSeconds % 60f);

        string formatedSeconds = seconds.ToString();

        if (seconds == 60)
        {
            seconds = 0;
            minutes += 1;
        }

        GetComponent<Text>().text = minutes.ToString("00") + "." + seconds.ToString("00");
    }
}
