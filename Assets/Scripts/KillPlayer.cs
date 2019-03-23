using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public string killingTrailTag = "Trail";

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" || collider.tag == killingTrailTag){
            Kill();
        }
    }

    public void Kill()
    {
        transform.position = World.GetRandomPosition();
        Trail trail = GetComponentInChildren<Trail>();
        trail.Clear();
    }
}
