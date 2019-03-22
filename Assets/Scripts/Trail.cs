using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Trail : MonoBehaviour
{
    public int max = 100;
    public float interval = 0.05f;

    private float lastEnqueue = 0;
    private int currentNum = 0;
    private Queue<Vector3> points;
    private LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
        points = new Queue<Vector3>();
        line = GetComponent<LineRenderer>();
        lastEnqueue = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentNum >= 100)
        {
            points.Dequeue();
            currentNum--;
        }

        if (Time.time >= lastEnqueue + interval)
        {
            lastEnqueue = Time.time;
            points.Enqueue(new Vector3(transform.position.x, transform.position.y));
            currentNum++;
        }

        Vector3[] arr = points.ToArray();
        line.positionCount = arr.Length;
        line.SetPositions(arr);
    }
}
