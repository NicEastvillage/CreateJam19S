using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiomanager : MonoBehaviour
{


    // Start is called before the first frame update

    
    AudioSource efxSource;                  
    public AudioSource wave;
    public AudioSource dead;
    public AudioSource gamebegin;
    public AudioSource pillpickup;
    public AudioSource soundtrack;
    public AudioSource menutrack;
    public AudioSource alert;
    public static audiomanager instance = null;     //Allows other scripts to call functions from SoundManager.             



    void Awake()
    {
        
        if (instance == null)
            
            instance = this;
       
        else if (instance != this)
           
            Destroy(gameObject);

       
        DontDestroyOnLoad(gameObject);
    }


    //Used to play single sound clips.
    public void PlayWave()
    {
        //Set the clip of our efxSource audio source to the clip passed in as a parameter.
        

        //Play the clip.
        wave.Play();
    }
    public void PlayDead()
    {
        dead.Play();
    }
    public void PlayPill()
    {
        pillpickup.Play();
    }
    public void PlayGamebegin()
    {
        gamebegin.Play();
    }
    public void PlaySoundtrack()
    {
        soundtrack.Play();
    }
    public void PlayMenutrack()
    {
        menutrack.Play();
    }
    public void StopMenutrack()
    {
        menutrack.Stop();
    }

    public void PlayAlert()
    {
        StartCoroutine(Alert());
    }

    IEnumerator Alert()
    {
        alert.Play();
        yield return new WaitForSeconds(5);
        alert.Play();
        yield return new WaitForSeconds(2);
        alert.Play();
        yield return new WaitForSeconds(1);
        alert.Play();
        yield return new WaitForSeconds(1);
        alert.Play();
        yield return new WaitForSeconds(1);
        alert.Play();
    }
}
