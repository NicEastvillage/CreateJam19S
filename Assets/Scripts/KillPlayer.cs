using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player Two")
        {
            // Do stuff
            onCollision();
            Debug.Log(other.name);
        }
        else if (other.name == "Player 1")
        {
            onCollision();
            Debug.Log(other.name);
        }

    }

    private void onCollision()
    {
        // Do collision stuff
    }
}
