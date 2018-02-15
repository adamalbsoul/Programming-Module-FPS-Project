using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m9Ammo : MonoBehaviour
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
            GameObject M9 = GameObject.Find("M9"); // find the pistol
            MachineGunScript mgs = M9.GetComponent<MachineGunScript>(); // get the script component of the pistol
            mgs.reserveAmmo += 20;  // add 20 ammo to the reserve
            Destroy(gameObject); // delete the ammo box
        }
    }
}
