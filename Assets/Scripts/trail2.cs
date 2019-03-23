using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trail2 : MonoBehaviour
{
    public GameObject tailprefab;
    public int trailamount;
    
    List<GameObject> trail = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Trail();
    }
    void Trail()
    {

        Vector2 v = transform.position;




        if (trail.Count < trailamount)
        {

            GameObject g = (GameObject)Instantiate(tailprefab, v,
                                              Quaternion.identity);
            trail.Add(g);

            

        }
        else
        {
            trail.RemoveAt(trail.Count - trail.Count+1);
            GameObject g = trail[trail.Count - trail.Count + 1];
            Destroy(g);
            GameObject f = (GameObject)Instantiate(tailprefab, v,
                                              Quaternion.identity);
            trail.Add(f);
            
        }
    }
}
