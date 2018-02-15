using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneTrigger : MonoBehaviour
{
    public AudioSource winSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") // if the object that enters the collider is tagged as Player
        {
            Application.LoadLevel("EndScene"); // EndScene loads
        }
    }
}
