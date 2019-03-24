using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class restartbutton : MonoBehaviour
{
    public void TaskOnClick()
    {
        audiomanager.instance.PlayGamebegin();
        SceneManager.LoadScene("Game");
    }
}