using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class playerScore : MonoBehaviour
{
    public GameObject p1Score;
    public GameObject p2Score;
    public int P1scorenum = 2;
    public int P2scorenum= 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        p1Score.GetComponent<Text>().text = "P1 SCORE:" + "\n " + P1scorenum.ToString();
        p2Score.GetComponent<Text>().text = "P2 SCORE:" + "\n " + P2scorenum.ToString();
    }

}
