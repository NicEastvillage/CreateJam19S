using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour{

    public Transform spawnPoint;
    public string killingTrailTag = "Trail_P1";

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Player Collision");
        if (collider.tag == "Player" || collider.tag == killingTrailTag){
            Kill();
        }
    }

    public void Kill()
    {
        transform.position = spawnPoint.transform.position;
    }
}
