﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle : MonoBehaviour
{

    
    public GameObject prefab;
    public int numberofcircles = 5;
    public float maxSize = 2;
    public float growFactor = 1.2f;
    public float waittime = 0.5f;
    public Vector3 wavepos;
    public bool atepil = true;
    // Use this for initialization
    void Start()
    {
        
        
       
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (atepil)
        {
            atepil = false;
           
            StartCoroutine(wave());
         
        }

       
        
        

    }
    IEnumerator wave()
    {
       
        
        
        
          for (int i = 0; i < numberofcircles; i++)
          {
              GameObject x = createCircle(wavepos, transform.localScale.x * 0.01f, transform.localScale.y * 0.01f);
            StartCoroutine(Scale(x));

            yield return new WaitForSeconds(waittime);
             

          }  
       
    }


    GameObject createCircle(Vector3 me, float x, float y)
    {
        GameObject circle =
        Instantiate(prefab,
            new Vector3(me.x , me.y, me.z/2),
            Quaternion.identity) as GameObject;
        circle.transform.localScale = new Vector3(x, y, 1);
        SpriteRenderer colordims = circle.GetComponent<SpriteRenderer>();
        Color Color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        Debug.Log(Color);
        colordims.color = Color;
        return circle;
    }
    private IEnumerator wait()
    {

        yield return new WaitForSeconds(0.5f);
        
    }

    IEnumerator Scale(GameObject ost)
    {
        float timer = 0;
        
        while (maxSize > ost.transform.localScale.x)
        {
            
            timer += Time.deltaTime;
            ost.transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * growFactor;
            
            yield return null;
        }
        if (maxSize < ost.transform.localScale.x)
        {
            Destroy(ost);
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            atepil = true;
            audiomanager.instance.PlayPill();
            audiomanager.instance.PlayWave();
            Movement playerMovement = collision.gameObject.GetComponent<Movement>();
            Trail trail = collision.gameObject.GetComponentInChildren<Trail>();
            Debug.Log(trail.max);
            trail.max += trail.increasePerPill;

            if (playerMovement.playerNumber == 2)
            {
                playerScore.AddP2Score(1);
            }
            else if (playerMovement.playerNumber == 1)
            {
                playerScore.AddP1Score(1);
            }
            else if (playerMovement.playerNumber == 3)
            {
                playerScore.AddP3Score(1);
            }
            wavepos = collision.gameObject.transform.position;
            Vector3 pos = World.GetRandomPosition();
            transform.position = pos;
        }


    }
}
