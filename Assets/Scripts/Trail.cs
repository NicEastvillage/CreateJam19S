﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Trail : MonoBehaviour
{

    public int max = 100;
    public int increasePerPill = 20;
    public float interval = 0.05f;
    public GameObject trailCollisionPrefab;
    public GameObject trailExplosionPrefab;
    
    private float lastEnqueue = 0;
    private int currentNum = 0;
    private Queue<Vector3> points;
    private Queue<GameObject> trailObjects;
    private LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
        points = new Queue<Vector3>();
        trailObjects = new Queue<GameObject>();
        line = GetComponent<LineRenderer>();
        lastEnqueue = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentNum >= max)
        {
            points.Dequeue();
            Destroy(trailObjects.Dequeue());
            currentNum--;
        }

        if (Time.time >= lastEnqueue + interval)
        {
            lastEnqueue = Time.time;
            Vector3 location = new Vector3(transform.position.x, transform.position.y);
            GameObject g = Instantiate(trailCollisionPrefab, location, Quaternion.identity, null) as GameObject;
            g.GetComponent<TrailDanger>().explosionPrefab = trailExplosionPrefab;
            trailObjects.Enqueue(g);
            points.Enqueue(location);
            currentNum++;
        }

        Vector3[] arr = points.ToArray();
        line.positionCount = arr.Length;
        line.SetPositions(arr);
    }

    public void Clear()
    {
        foreach (GameObject g in trailObjects)
        {
            Destroy(g);
        }

        points = new Queue<Vector3>();
        trailObjects = new Queue<GameObject>();
        currentNum = 0;

        line.positionCount = 0;
    }
}
