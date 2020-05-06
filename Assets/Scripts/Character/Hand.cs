using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    public GameObject weaponText;
    public int nWeapon = 2;
    public int weapon = 1;
    [Space]
    public GameObject flashlight;
    public AudioSource flashlightSound;
    [Space]
    public GameObject panelPistol;
    public bool hasPistol = true;

    // public GameObject panelShotgun;
    // public bool hasShotgun = false;

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (weapon < nWeapon)
            {
                weapon++;
            }
            else
            {
                weapon = 1;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (weapon > 1)
            {
                weapon--;
            }
            else
            {
                weapon = nWeapon;
            }
        }

        // Flashlight
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashlight.SetActive(!flashlight.activeSelf);
            flashlightSound.Play();
        }

        // Choix de l'arme

        switch (weapon)
        {
            case 1:
                if (hasPistol)
                {
                    weaponText.GetComponent<UnityEngine.UI.Text>().text = "Pistol";
                    panelPistol.SetActive(true);
                }
                else
                {
                    weaponText.GetComponent<UnityEngine.UI.Text>().text = "";
                }
                // panelShotgun.SetActive(false);
                break;
            /*case 2:
                if (hasShotgun)
                {
                    weaponText.GetComponent<UnityEngine.UI.Text>().text = "Shotgun";
                    panelShotgun.SetActive(true);
                }
                else
                {
                    weaponText.GetComponent<UnityEngine.UI.Text>().text = "";
                }
                panelPistol.SetActive(false);
                break;*/
        }
    }
}
