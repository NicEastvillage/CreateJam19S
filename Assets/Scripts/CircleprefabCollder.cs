﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleprefabCollder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Tile")
        {
            GameObject g = collider.gameObject;
            SpriteRenderer colordims = g.GetComponent<SpriteRenderer>();
            SpriteRenderer circlerenderer = GetComponent<SpriteRenderer>();
            colordims.color = circlerenderer.color;
        }
    }
}
