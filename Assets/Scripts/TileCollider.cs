using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCollider : MonoBehaviour
{   bool collided;
    Color Startcolor;
    float currenttimer;
    public float maxtimer = 0.5f;
    private Transform transform;
    public float camshakeduration =0.1f;
    private float shakeDuration = 0f;
    private bool backshake = false;
    public float increaseofmag = 0.05f;
    public float shakeMagnitude = 0.7f;
    public float secondstoincreasemag = 15;
    public Vector3 initialPosition;
    public float dampingSpeed = 1.0f;
    public bool mode = false;
    public SpriteRenderer colordims;
    // Start is called before the first frame update
    void Awake()
    {
        if (transform == null)
        {
            transform = GetComponent(typeof(Transform)) as Transform;
        }
    }
        void Start()
    {
        colordims = GetComponent<SpriteRenderer>();
        Startcolor = colordims.color;
        
    }

    // Update is called once per frame
    void OnEnable()
    {
        initialPosition = transform.localPosition;
    }
    void Update()
    {
     if (currenttimer > maxtimer)
        {
            SpriteRenderer color = GetComponent<SpriteRenderer>();
            color.color = Startcolor;
           /* if (backshake)
            {
                shakeDuration = camshakeduration;
                backshake = false;
            }
            */
            currenttimer = 0;
            checktimer();
        }
        else
        {
            currenttimer = currenttimer + Time.deltaTime;
        }
        if (shakeDuration > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude*shakeDuration;

            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = initialPosition;
        }
        if (timer.instance.totalTime < 30 && !mode){
            mode = true;
            
            StartCoroutine(hypermode());
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Circle") { 
            currenttimer = 0;
        shakeDuration = camshakeduration;
            backshake = true;
    }
        
    }
    public void checktimer()
    {
        float time = timer.instance.totalTime;
        if (time % secondstoincreasemag < 0.2f)
        {
            shakeMagnitude += increaseofmag;
        }

    }
    IEnumerator hypermode()
    {
        Color Color = new Color(1, 0,0);
        Startcolor = Color;
        yield return new WaitForSeconds(0.75f);
        StartCoroutine(hypermode2());
    

    }
    IEnumerator hypermode2()
    {
        Color Color = new Color(0,1,0);
        Startcolor = Color;
        yield return new WaitForSeconds(0.75f);
        StartCoroutine(hypermode3());


    }
    IEnumerator hypermode3()
    {
        Color Color = new Color(0,0,1);
        Startcolor = Color;
        yield return new WaitForSeconds(0.75f);
        StartCoroutine(hypermode());


    }
}
