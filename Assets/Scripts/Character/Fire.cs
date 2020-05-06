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

    Color panelColor;

    void Start()
    {
        panelColor = panelPistol.color;
    }

    void Update()
    {
        textPistol.text = ammoPistol + " | " + ammoPBag;

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
                    }
                    else
                    {
                        noAmmo.Play();
                    }
                    break;
                /* case 2:
                    Instantiate(bullet, spawnPoint.position, spawnPoint.rotation * Quaternion.Euler(0, Random.Range(-20f, 20f), 0), gameObject.transform);
                    Instantiate(bullet, spawnPoint.position, spawnPoint.rotation * Quaternion.Euler(0, Random.Range(-20f, 20f), 0), gameObject.transform);
                    Instantiate(bullet, spawnPoint.position, spawnPoint.rotation * Quaternion.Euler(0, Random.Range(-20f, 20f), 0), gameObject.transform);
                    Instantiate(bullet, spawnPoint.position, spawnPoint.rotation * Quaternion.Euler(0, Random.Range(-20f, 20f), 0), gameObject.transform);
                    Instantiate(bullet, spawnPoint.position, spawnPoint.rotation * Quaternion.Euler(0, Random.Range(-20f, 20f), 0), gameObject.transform);

                    soundShotgun.Play();
                    break;*/
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
