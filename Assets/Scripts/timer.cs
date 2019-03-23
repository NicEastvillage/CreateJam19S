using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class timer : MonoBehaviour
{
    
    
    public float totalTime;
    public GameObject gameover;
    public GameObject firstplace;
    public GameObject secondplace;
    public GameObject timerUI;
    public GameObject p1scoreUI;
    public GameObject p2scoreUI;
    public GameObject map;
    public GameObject p1;
    public GameObject p2;
    public GameObject rebutton;
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
        else { gameisover(); }
        
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
    private void gameisover()
    {
        int p1score = playerScore.getP1Score();
        int p2score = playerScore.getP2Score();
        if (p1score >p2score)
        {
            gameover.GetComponent<Text>().text = "GAME OVER" + "\n "+ "PLAYER 1 WON";
            firstplace.GetComponent<Text>().text = "Player 1: " + p1score.ToString();
            secondplace.GetComponent<Text>().text = "Player 2: " + p2score.ToString();
        }
        else if (p1score < p2score)
        {
            gameover.GetComponent<Text>().text = "GAME OVER" + "\n " + "PLAYER 2 WON";
            firstplace.GetComponent<Text>().text = "Player 2: " + p2score.ToString();
            secondplace.GetComponent<Text>().text = "Player 1: " + p1score.ToString();
        }
        else
        {
            gameover.GetComponent<Text>().text = "GAME OVER" + "\n " + "DRAW";
            firstplace.GetComponent<Text>().text = "Player 2: " + p2score.ToString();
            secondplace.GetComponent<Text>().text = "Player 1: " + p1score.ToString();
        }
        gameover.SetActive(true);
        firstplace.SetActive(true);
        secondplace.SetActive(true);
        rebutton.SetActive(true);
        timerUI.SetActive(false);
         p1scoreUI.SetActive(false);
         p2scoreUI.SetActive(false);
        map.SetActive(false);
        p1.SetActive(false);
        p2.SetActive(false);
    }
}
