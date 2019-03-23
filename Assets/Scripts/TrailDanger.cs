﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailDanger : MonoBehaviour
{
    public string trailTag = "Trail";
    
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            gameObject.tag = trailTag;
        }
    }
}