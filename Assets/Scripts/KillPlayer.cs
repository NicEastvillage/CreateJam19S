using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour{

    public Transform spawnPoint;
    public string killingTrailTag = "Trail_P1";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" || collision.collider.tag == killingTrailTag){
            Kill();
        }
    }

    public void Kill()
    {
        transform.position = spawnPoint.transform.position;
    }
}
