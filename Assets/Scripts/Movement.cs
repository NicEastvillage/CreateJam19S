using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private int playerNumber;
    [SerializeField ]private float moveSpeed = 5f;
    //public float distance = 0f;  
    public KeyCode left;
    public KeyCode right;
    public KeyCode up;
    public KeyCode down;
    public GameObject gameObejct;
    private Vector2 moveDirection = Vector2.zero;
    

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
        switch (playerNumber)
        {
            case 1:
                //Debug.Log("Horizontal: " + Input.GetAxis("PS4_1_Horizontal"));
                //Debug.Log("Horizontal: " + Input.GetAxis("PS4_1_Vertical"));
                if (Input.GetAxis("PS4_1_Horizontal") > 0)
                {
                    gameObejct.transform.Translate((new Vector2(moveSpeed*Time.deltaTime, 0)));
                } else if (Input.GetAxis("PS4_1_Horizontal") < 0 )
                {
                    gameObejct.transform.Translate(new Vector2(-moveSpeed * Time.deltaTime, 0));
                } else if (Input.GetAxis("PS4_1_Vertical") > 0)
                {
                    gameObejct.transform.Translate(new Vector2(0, moveSpeed * Time.deltaTime));
                } else if (Input.GetAxis("PS4_1_Vertical") < 0)
                {
                    gameObejct.transform.Translate(new Vector2(0, -moveSpeed * Time.deltaTime));
                }
               // moveDirection = new Vector2(Input.GetAxis("PS4_1_Horizontal"), Input.GetAxis("PS4_1_Vertical"));
               // gameObejct.transform.Translate(moveDirection);
                //moveDirection *= moveSpeed;
                break;
            case 2:

                if (Input.GetAxis("PS4_2_Horizontal") > 0)
                {
                    gameObejct.transform.Translate((new Vector2(moveSpeed * Time.deltaTime, 0)));
                }
                else if (Input.GetAxis("PS4_2_Horizontal") < 0)
                {
                    gameObejct.transform.Translate(new Vector2(-moveSpeed * Time.deltaTime, 0));
                }
                else if (Input.GetAxis("PS4_2_Vertical") > 0)
                {
                    gameObejct.transform.Translate(new Vector2(0, moveSpeed * Time.deltaTime));
                }
                else if (Input.GetAxis("PS4_2_Vertical") < 0)
                {
                    gameObejct.transform.Translate(new Vector2(0, -moveSpeed * Time.deltaTime));
                }
                //moveDirection = new Vector2(Input.GetAxis("PS4_2_Horizontal"), Input.GetAxis("PS4_2_Vertical"));
                //gameObejct.transform.Translate(moveDirection);
                //moveDirection *= moveSpeed;
                break;
        }

        if (Input.GetKey(left))
        {
            gameObejct.transform.Translate(new Vector2(-moveSpeed * Time.deltaTime, 0));
            //Debug.Log("A: Pressed");
        }
        else if (Input.GetKey(right))
        {
            gameObejct.transform.Translate(new Vector2(moveSpeed * Time.deltaTime, 0));
            //Debug.Log("D: Pressed");
        }
        else if (Input.GetKey(up))
        {
            gameObejct.transform.Translate(new Vector2(0, moveSpeed * Time.deltaTime));
            //Debug.Log("W: Pressed");
        }
        else if (Input.GetKey(down))
        {
            gameObejct.transform.Translate(new Vector2(0, -moveSpeed * Time.deltaTime));
            //Debug.Log("S: Pressed");
        }
    }

    
}
