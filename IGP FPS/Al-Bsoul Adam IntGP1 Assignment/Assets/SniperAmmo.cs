using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperAmmo : MonoBehaviour
{
    public int x;
    public int y;
    public int z;
    public AudioSource pickupSound;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(x, y, z) * Time.deltaTime); // rotates the object
    }

    void OnTriggerEnter(Collider a)
    {
        if (a.gameObject.tag == "Player") // if the player enters the collider
        {
            Debug.Log("entered");
            pickupSound.GetComponent<AudioSource>().Play();
            GameObject Sniper = GameObject.Find("Sniper"); // find the sniper rifle
            MachineGunScript mgs2 = Sniper.GetComponent<MachineGunScript>(); // get the script component of the sniper rifle
            mgs2.reserveAmmo += 10; // add 10 ammo to the reserve
            Destroy(gameObject); // delete the ammo box
        }
    }
}
