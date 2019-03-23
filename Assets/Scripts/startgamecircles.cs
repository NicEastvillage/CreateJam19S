using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startgamecircles : MonoBehaviour
{

    public GameObject prefab;
    public GameObject pill1;
    public GameObject pill2;
    public GameObject pill3;
    public GameObject pill4;
    
    int numberofcircles = 2;
     float maxSize = 20;
     float growFactor = 5.2f;
     float waittime = 2.5f;
    float timer = 0;

    public bool atepil = true;
    // Use this for initialization
    void Start()
    {





    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer> waittime) {

            int rand = (int)Random.Range(0, 4);
            if (rand == 0)
            {
                StartCoroutine(wave(pill1));
            }
            if (rand == 1)
            {
                StartCoroutine(wave(pill2));
            }
            if (rand == 2)
            {
                StartCoroutine(wave(pill3));
            }
            if (rand == 3)
            {
                StartCoroutine(wave(pill4));
            }

            timer = 0;
        }

            

       





    }
    IEnumerator wave(GameObject pill)
    {

        


        for (int i = 0; i < numberofcircles; i++)
        {
            GameObject x = createCircle(pill.transform.position, pill.transform.localScale.x * 0.1f, pill.transform.localScale.y * 0.1f);
            StartCoroutine(Scale(x));

            yield return new WaitForSeconds(waittime);


        }

    }


    GameObject createCircle(Vector3 me, float x, float y)
    {
        GameObject circle =
        Instantiate(prefab,
            new Vector3(me.x, me.y, me.z / 2),
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
        if (maxSize < ost.transform.localScale.x)
        {
            Destroy(ost);
        }


    }

}
