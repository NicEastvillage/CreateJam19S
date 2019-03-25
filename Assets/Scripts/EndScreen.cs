using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
	public GameObject player1;
	public GameObject player2;
    public GameObject player3;
    public GameObject blueWins;
	public GameObject orangeWins;
    public GameObject greenWins;
    public GameObject draw;

	// Start is called before the first frame update
	void Start()
    {
		gameisover();
    }

    private void gameisover()
    {
        int p1score = playerScore.getP1Score();
        int p2score = playerScore.getP2Score();
        int p3score = playerScore.getP3Score();
        player1.GetComponent<Text>().text = "SCORE: " + p1score.ToString();
		player2.GetComponent<Text>().text = "SCORE: " + p2score.ToString();
        player3.GetComponent<Text>().text = "SCORE: " + p3score.ToString();
        if (p1score > p2score && p1score > p3score) // Blue wins
		{
			blueWins.SetActive(true);
			orangeWins.SetActive(false);
			draw.SetActive(false);
            greenWins.SetActive(false);
        }
		else if (p2score > p1score && p2score > p3score) // Orange wins
		{
			orangeWins.SetActive(true);
			blueWins.SetActive(false);
			draw.SetActive(false);
            greenWins.SetActive(false);
        }
        else if (p3score > p1score && p3score > p2score) // Green wins
        {
            orangeWins.SetActive(false);
            blueWins.SetActive(false);
            greenWins.SetActive(true);
            draw.SetActive(false);
        }
        else // Its a DRAW
		{
			draw.SetActive(true);
			orangeWins.SetActive(false);
			blueWins.SetActive(false);
            greenWins.SetActive(false);
        }
    }
}
