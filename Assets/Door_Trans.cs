using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Trans : MonoBehaviour
{
    public GameObject door;
    public AudioSource soundDoor;
    public float velocity = 1.0f;
    [Space]
    public bool open = false;

    float positionDoor = 0.0f;
    bool play = false;

    void Update()
    {
        if (open && positionDoor < 0.055f)
        {
            if (!play)
            {
                soundDoor.Play();
                play = true;
            }
            positionDoor += Time.deltaTime * velocity;

            if (positionDoor > 0.055f)
            {
                positionDoor = 0.055f;
                play = false;
            }
        }
        else if (!open && positionDoor > 0)
        {
            if (!play)
            {
                soundDoor.Play();
                play = true;
            }
            positionDoor -= Time.deltaTime * velocity;

            if (positionDoor < 0)
            {
                positionDoor = 0.0f;
                play = false;
            }
        }

        door.transform.localPosition = new Vector3(0, positionDoor, 0);
    }
}
