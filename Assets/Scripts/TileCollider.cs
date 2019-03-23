using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCollider : MonoBehaviour
{   bool collided;
    Color Startcolor;
    int changecolorbacktime=2;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer colordims = GetComponent<SpriteRenderer>();
        Startcolor = colordims.color;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        StartCoroutine(OnTriggerEnterresetcolor(collision));
        
    }
   

    IEnumerator OnTriggerEnterresetcolor(Collider2D collider)
    {
        
        yield return new WaitForSeconds(changecolorbacktime);
       
           SpriteRenderer color = GetComponent<SpriteRenderer>();
            color.color = Startcolor;
        
    }

   
}
