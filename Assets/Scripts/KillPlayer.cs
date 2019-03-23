using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour{

    [SerializeField] private GameObject player;
    [SerializeField] private Transform spawnPoint;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player"){
            player.transform.position = spawnPoint.transform.position;
        }
    }
}
