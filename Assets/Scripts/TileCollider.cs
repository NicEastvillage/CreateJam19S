using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCollider : MonoBehaviour
{   bool collided;
    Color Startcolor;
    float currenttimer;
    public float maxtimer = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer colordims = GetComponent<SpriteRenderer>();
        Startcolor = colordims.color;
        
    }

    // Update is called once per frame
    void Update()
    {
     if (currenttimer > maxtimer)
        {
            SpriteRenderer color = GetComponent<SpriteRenderer>();
            color.color = Startcolor;
            currenttimer = 0;
        }
        else
        {
            currenttimer = currenttimer + Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        currenttimer = 0;
        
    }
    
}
