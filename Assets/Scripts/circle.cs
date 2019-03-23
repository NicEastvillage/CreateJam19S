using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle : MonoBehaviour
{    
    public float size=.01f;
    public float waittime = 10f;
    public GameObject prefab;
    int numberofcircles = 10;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(wave());
        
    }

    // Update is called once per frame
    void Update()
    {
        

       
        
        

    }
    IEnumerator wave()
    {
        Vector3 me = this.transform.position;
        Vector3 mysize = this.transform.localScale;
        for (int i = 0; i < numberofcircles; i++)
        {
            size += 0.1f;
            GameObject ost = createCircle(me, size+mysize.x, size+mysize.y);
            SpriteRenderer colordims = ost.GetComponent<SpriteRenderer>();
            colordims.color = (new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255)));
            yield return new WaitForSeconds(waittime);
            Destroy(ost);
            
        }    
    }


    GameObject createCircle(Vector3 me, float x, float y)
    {
        GameObject circle =
        Instantiate(prefab,
            new Vector3(me.x / 2, me.y / 2, me.z/2),
            Quaternion.identity) as GameObject;
        circle.transform.localScale = new Vector3(x, y, 1);
        SpriteRenderer colordims = circle.GetComponent<SpriteRenderer>();
        colordims.color = (new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255)));
        return circle;
    }
    private IEnumerator wait()
    {

        yield return new WaitForSeconds(3);
    }
}