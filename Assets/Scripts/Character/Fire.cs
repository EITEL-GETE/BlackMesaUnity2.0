using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;

    public AudioSource soundPistol;
    public Image panelPistol;
    public Text textPistol;
    public int ammoPistol = 17;
    public int ammoPBag = 17;

    // public AudioSource soundShotgun;

    public AudioSource noAmmo;
    public AudioSource reload;

    public GameObject gun;
    public GameObject cursor;
    public GameObject lazer;

    LayerMask cursorDetection;

    Color panelColor;

    void Start()
    {
        panelColor = panelPistol.color;
    }

    void Update()
    {
        textPistol.text = ammoPistol + " | " + ammoPBag;

        RaycastHit cursorLoc;

        if (Physics.Raycast(spawnPoint.position, spawnPoint.TransformDirection(Vector3.forward) * 10, out cursorLoc))
        {
            if (cursorLoc.collider != null)
            {
                cursor.transform.position = cursorLoc.point;
                lazer.GetComponent<LineRenderer>().SetPosition(1, cursor.transform.localPosition);
            }
        }

        Debug.DrawRay(spawnPoint.position, spawnPoint.TransformDirection(Vector3.forward) * 10, Color.yellow);

        if (Input.GetButtonDown("Fire1"))
        {
            switch (GameObject.Find("Character").GetComponent<Hand>().weapon)
            {
                case 1:
                    if (ammoPistol > 0)
                    {
                        Instantiate(bullet, spawnPoint.position, spawnPoint.rotation * Quaternion.Euler(0, 0, 0), gameObject.transform);
                        soundPistol.Play();
                        ammoPistol--;
                        gun.GetComponent<handGun>().fire = true;
                    }
                    else
                    {
                        noAmmo.Play();
                    }
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

        if (ammoPBag == 0 && ammoPistol == 0)
        {
            panelPistol.color = new Color(1, 0, 0, 0.4f);
            textPistol.color = new Color(1, 0, 0);
        }
        else
        {
            panelPistol.color = panelColor;
            textPistol.color = new Color(panelColor.r, panelColor.g, panelColor.b);
        }
    }

    void Reload()
    {
        if (ammoPistol < 17 && ammoPBag > 0)
        {
            reload.Play();

            if (ammoPBag >= (17 - ammoPistol))
            {
                ammoPBag -= (17 - ammoPistol);
                ammoPistol = 17;
            }
            else
            {
                ammoPistol += ammoPBag;
                ammoPBag = 0;
            }
        }
    }
}
