﻿using System.Collections;
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
    public int secondsforspeedtorise = 15;
    public float speedraise = 0.1f;

    public bool timerisout= false;
    private void FixedUpdate()
    {
        
        if (totalTime % secondsforspeedtorise < 0.2f)
        {
            
            increasemovespeed();
           
        }
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
    public void increasemovespeed()
    {
        GameObject player1 = GameObject.Find("Player_1");
        Movement script = player1.GetComponent<Movement>();
        script.moveSpeed += speedraise;

        GameObject player2 = GameObject.Find("Player_2 (1)");
        Movement script2 = player2.GetComponent<Movement>();
        script2.moveSpeed += speedraise;
    }
}
