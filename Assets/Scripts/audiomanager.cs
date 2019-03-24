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

}
