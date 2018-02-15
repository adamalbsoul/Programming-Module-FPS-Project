using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MachineGunScript : MonoBehaviour
{
    // Shooting
    public float damage = 10;
    public Camera fpsCam;
    public float impactForce = 30;
    public float fireRate = 15f;
    private float nextTimeToFire = 0;

    // Sound
    public AudioClip audShot;
    public AudioClip audReload;
    public AudioSource hitSoundEffect;

    // Muzzle flash
    public GameObject muzzleFlash;
    float timeToDisable = 0.0f;

    // Crosshair
    public GameObject crosshair;
    public GameObject crosshairRed;

    // Ammo
    public int maxAmmo = 10;
    int lastClip = 0;
    public int reserveAmmo = 60;
    public int reloadAmmo;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;
    public Animator animator;
    public Text magAmmoText;
    public Text reserveAmmoText;

    void Start()
    {
        if (currentAmmo == -1)
            currentAmmo = maxAmmo; // equates the current clip to the maximum it can hold
        // draws the default crosshair
        crosshair.SetActive(true); // white crosshair gets displayed
        crosshairRed.SetActive(false); // red crosshair doesn't get displayed
    }

    void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }


    // Update is called once per frame
    void Update()
    {

        if (isReloading)
            return; // doesn't go further down the code of the Update() method

        if (currentAmmo <= 0 && reserveAmmo > 0 || (Input.GetKey(KeyCode.R))) // if the player runs out of ammo and has enough ammo, the game reloads the gun automatically, or the player can press R to reload manually
        {
            StartCoroutine(Reload()); // starts the coroutine for relading
            return;// doesn't go further down the code of the Update() method
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && currentAmmo > 0) // checks if the player has clicked LMB, checks if it's time to shoot, checks if there is enough ammo to shoot
        {
            nextTimeToFire = Time.time + 1f / fireRate; // sets the firerate by dividing the current time (+1 second) by a public fire rate value

            Shoot(); // starts the Shoot() method
        }

        if (timeToDisable <= 0.0f) // if the time isn't to shoot
        {
            muzzleFlash.SetActive(false); // the muzzle flash doesn't display
        }
        else
        {
            timeToDisable -= Time.deltaTime;
        }

        magAmmoText.text = currentAmmo.ToString(); // displays current ammo
        reserveAmmoText.text = reserveAmmo.ToString(); // displays reserve ammo

        // change color to red if there isn't much ammo
        if (currentAmmo <= 3) // if ammo is low...
        {
            magAmmoText.color = Color.red; // ... the color of the text notifies the player by changing the text to red
        }
        if (reserveAmmo <= 3)
        {
            reserveAmmoText.color = Color.red;
        }
        if (currentAmmo > 3) // if ammo isn't low ...
        {
            magAmmoText.color = Color.green; // ... the color is green
        }
        if (reserveAmmo > 3)
        {
            reserveAmmoText.color = Color.green;
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        muzzleFlash.SetActive(false);
        Debug.Log("Reloading");

        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(audReload);
        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime - .25f);
        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(.25f);

        // Replaces used ammo (lastClip) with ammo from reserve (reserveAmmo); then resets used ammo counter (lastClip)
        if (reserveAmmo > 0)
        {
            currentAmmo = maxAmmo;
            reserveAmmo = reserveAmmo - lastClip;
            lastClip = 0;
        }

        // Makes sure that the reserve ammo doesn't become something ilogical like a negative number
        if (reserveAmmo < 0)
        {
            reserveAmmo = 0;
        }

        isReloading = false;
    }

    void Shoot() // If the player clicks LMB, raycast checks if it's the target. If it is, it deals damage
    {
        currentAmmo--; // subtracts one bullet from current clip
        lastClip++; // adds 1 bullet to int that is going to be subtracted from reserveAmmo when player reloads

        // Muzzleflash
        muzzleFlash.SetActive(true);
        timeToDisable = 0.02f;

        //GetComponent<AudioSource>().Play();
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(audShot);

        // Shooting
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit)) // a raycast comes out of the player's camera
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>(); // if the target is hit
            if (target != null)
            {
                target.TakeDamage(damage); // takes damage
                hitSoundEffect.GetComponent<AudioSource>().Play();
            }

            if (hit.rigidbody != null) // if a rigidbody is hit
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce); // force is added to the rigid body, multiplied by a public var for the impactForce
            }
            // Coroutine to show red crosshair
            StartCoroutine(CrosshairShot());
        }

        crosshairRed.SetActive(true); // displays the red crosshair when the player is shooting
        crosshair.SetActive(false);

    }

    public IEnumerator CrosshairShot()
    {
        yield return new WaitForSeconds(0.1f);
        // Crosshair changes color to red when the gun is shooting
        crosshair.SetActive(true);
        crosshairRed.SetActive(false);
    }
}
