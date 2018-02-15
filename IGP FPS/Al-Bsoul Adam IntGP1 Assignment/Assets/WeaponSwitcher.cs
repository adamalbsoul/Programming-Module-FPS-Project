using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitcher : MonoBehaviour
{
    public int selectedWeapon = 0;
    public Text m9;
    public Text m4;
    public Text sniper;

    // Use this for initialization
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
                selectedWeapon = transform.childCount - 1;
            else
                selectedWeapon--;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) // if "1" is pressed ...
        {
            selectedWeapon = 0; // the selected weapon changes to the 0th weapon
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            selectedWeapon = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            selectedWeapon = 2;
        }

        if (previousSelectedWeapon != selectedWeapon) // enables the scroll function
        {
            SelectWeapon();
        }

        if (selectedWeapon == 0) // if the selected weapon is the 0th one, ie. the m9 pistol
        {
            m9.color = Color.red; // the text changes color to red to notify the player of the change
            m4.color = Color.green;
            sniper.color = Color.green;
        }

        if (selectedWeapon == 1)
        {
            m9.color = Color.green;
            m4.color = Color.red;
            sniper.color = Color.green;
        }

        if (selectedWeapon == 2)
        {
            m9.color = Color.green;
            m4.color = Color.green;
            sniper.color = Color.red;
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
