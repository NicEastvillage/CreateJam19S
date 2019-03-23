using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class restartbutton : MonoBehaviour
{
    public void TaskOnClick()
    {
        SceneManager.LoadScene("Game");
    }
}