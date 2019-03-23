using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class playerScore : MonoBehaviour
{
    public Text p1Score;
    public Text p2Score;
    public int P1scorenum = 2;
    public int P2scorenum= 5;

    private static playerScore _instance;

    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
        UpdateScores();
    }

    void UpdateScores()
    {
        p1Score.text = "P1 SCORE:" + "\n " + P1scorenum.ToString();
        p2Score.text = "P2 SCORE:" + "\n " + P2scorenum.ToString();
       
    }

    public static void AddP1Score(int score)
    {
        _instance.P1scorenum += score;
        _instance.UpdateScores();
    }

    public static void AddP2Score(int score)
    {
        _instance.P2scorenum += score;
        _instance.UpdateScores();
    }
}
