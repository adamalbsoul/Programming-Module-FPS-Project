using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject prefab;
    public AudioSource spawnSound;

    void OnTriggerEnter() // when the player enters the trigger
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length); // a random spawnpoint is chosen
        spawnSound.GetComponent<AudioSource>().Play(); // plays sound to notify player of the spawning
        Instantiate(prefab, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation); // spawns a prefab (barrel) in the position of the spawnpoint
    }
}
