using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeBehavior : MonoBehaviour
{
    
    private Transform transform;
    public static ShakeBehavior instance = null;
    public float camshakeduration;
    private float shakeDuration = 0f;

    
    public float shakeMagnitude = 0.7f;

    
    public float dampingSpeed = 1.0f;

    
    public Vector3 initialPosition;

    void Awake()
    {
        if (transform == null)
        {
            transform = GetComponent(typeof(Transform)) as Transform;
        }
        if (instance == null)

            instance = this;

        else if (instance != this)

            Destroy(gameObject);
    }
    void OnEnable()
    {
        initialPosition = transform.localPosition;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeDuration > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = initialPosition;
        }
    }
    public void TriggerShake()
    {
        shakeDuration = camshakeduration;
    }
}
