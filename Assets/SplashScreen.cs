using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
	public GameObject splashPresent;

    // Start is called before the first frame update
    void Start()
    {
		Invoke("UpdateSplash", 2);
    }

    
	void UpdateSplash()
	{
		splashPresent.SetActive(true);
		gameObject.SetActive(false);
		Invoke("LaunchMenu", 2);
	}

	void LaunchMenu()
	{
		SceneManager.LoadScene("StartMenu");
	}

}
