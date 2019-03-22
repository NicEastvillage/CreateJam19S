using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 0f;
    //public float distance = 0f;  
    public KeyCode left;
    public KeyCode right;
    public KeyCode up;
    public KeyCode down;
    public GameObject gameObejct;

    // Start is called before the first frame update
    void Start()
    {
        gameObejct.GetComponent<GameObject>();   
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    void movement()
    {
        if (Input.GetKey(left))
        {
            gameObejct.transform.Translate(new Vector2(-moveSpeed * Time.deltaTime, 0));
            Debug.Log("A: Pressed");
        }
        else if (Input.GetKey(right))
        {
            gameObejct.transform.Translate(new Vector2(moveSpeed * Time.deltaTime, 0));
            Debug.Log("D: Pressed");
        }
        else if (Input.GetKey(up))
        {
            gameObejct.transform.Translate(new Vector2(0, moveSpeed * Time.deltaTime));
            Debug.Log("W: Pressed");
        }
        else if (Input.GetKey(down))
        {
            gameObejct.transform.Translate(new Vector2(0, -moveSpeed * Time.deltaTime));
            Debug.Log("S: Pressed");
        }
    }

    
}
