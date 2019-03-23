using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class playerScore : MonoBehaviour
{
    public Text p1Score;
    public Text p2Score;
    public int P1scorenum = 0;
    public int P2scorenum= 0;

    private static playerScore _instance;

    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
        UpdateScores();
    }

    void UpdateScores()
    {
        p1Score.text = P1scorenum.ToString();
        p2Score.text = P2scorenum.ToString();
       
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
    public static int getP2Score()
    {
        return _instance.P2scorenum;
        
    }
    public static int getP1Score()
    {
        return _instance.P1scorenum;
        
    }
}
