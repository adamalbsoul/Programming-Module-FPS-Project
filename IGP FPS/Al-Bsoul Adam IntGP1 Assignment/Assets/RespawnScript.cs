using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{

    public GameObject spawnPoint; // var for the point where the player should teleport to

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Respawn") // if the player enters the trigger of the respawn collider
        {
            this.transform.position = spawnPoint.transform.position; // get the position values of the spawnpoint and change the current position values to those of the spawnpoint
        }
    }
}
