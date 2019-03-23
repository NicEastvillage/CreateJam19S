using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle : MonoBehaviour
{    
    public float size=.01f;
    public float waittime = 10f;
    public GameObject prefab;
    int numberofcircles = 10;
    public float maxSize = 2;
    public float growFactor = 1.2f;
    public float waitTime=0.2f;
    // Use this for initialization
    void Start()
    {
        
        Vector3 me = this.transform.position;
        Vector3 mysize = this.transform.localScale;
        GameObject ost = createCircle(me, mysize.x, mysize.y);
        StartCoroutine(Scale(ost));
    }

    // Update is called once per frame
    void Update()
    {
        

       
        
        

    }
    IEnumerator wave()
    {
        Vector3 me = this.transform.position;
        Vector3 mysize = this.transform.localScale;
        GameObject ost = createCircle(me, mysize.x, mysize.y);
        /*  for (int i = 0; i < numberofcircles; i++)
          {
              size += 0.1f;
              

              yield return new WaitForSeconds(waittime);
              Destroy(ost);

          }  */
        yield return new WaitForSeconds(1);
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

        yield return new WaitForSeconds(3);
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
               
    }
}
