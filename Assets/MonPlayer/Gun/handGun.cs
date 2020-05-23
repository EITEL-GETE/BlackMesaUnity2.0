using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handGun : MonoBehaviour
{
    public GameObject head;
    public float velocity = 1.0f;

    public bool fire = false;
    public float power = 5;
    bool temp = true;

    void Update()
    {
        if (fire && temp)
        {
            if (head.transform.localPosition.x < 0.004f)
            {
                head.transform.localPosition = new Vector3(head.transform.localPosition.x + Time.deltaTime * velocity, 0, 0);
            }
            else
            {
                temp = false;
            }
        }
        if (fire && ! temp)
        {
            if (head.transform.localPosition.x > 0)
            {
                head.transform.localPosition = new Vector3(head.transform.localPosition.x - Time.deltaTime * velocity, 0, 0);
            }
            if (head.transform.localPosition.x < 0)
            {
                head.transform.localPosition = new Vector3(0, 0, 0);

                fire = false;
                temp = true;
            }
        }
    }
}
