using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public string killingTrailTag = "Trail";

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" || collider.tag == killingTrailTag)
        {
            Movement m = GetComponent<Movement>();
            if (m.pausedMovementTimer <= 0f)
            {
                TrailDanger td = collider.gameObject.GetComponent<TrailDanger>();
                if (td != null)
                {
                    GameObject g = Instantiate(td.explosionPrefab, transform.position, Quaternion.identity, null);
                    Destroy(g, 2);
                }
                else
                {
                    GameObject explosionPrefab = GetComponentInChildren<Trail>().trailExplosionPrefab;
                    GameObject g = Instantiate(explosionPrefab, transform.position, Quaternion.identity, null);
                    Destroy(g, 2);
                }
            }
            
            Kill();
        }
        else if (collider.tag == "Wall")
        {
            Kill();
        }
    }

    public void Kill()
    {

        ShakeBehavior.instance.TriggerShake();
        audiomanager.instance.PlayDead();
        int i = Random.Range(0, 4);

        if (i ==3)
        { 
            World._instance.spawndeathtile(transform.position);
           
        }
        transform.position = World.GetRandomPosition();
        Trail trail = GetComponentInChildren<Trail>();
        trail.Clear();

        GetComponent<Movement>().PauseMovement();
    }
}
