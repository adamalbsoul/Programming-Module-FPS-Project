using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m4Ammo : MonoBehaviour
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
            GameObject M4a1 = GameObject.Find("M4a1"); // find the machinegun
            MachineGunScript mgs1 = M4a1.GetComponent<MachineGunScript>(); // get the script component of the machinegun
            mgs1.reserveAmmo += 30; // add 30 ammo to the reserve
            Destroy(gameObject); // delete the ammo box
        }
    }
}
