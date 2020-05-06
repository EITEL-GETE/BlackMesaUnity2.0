using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float velocity = 1.0f;

    float time = 0.1f;
    float temp = 0.0f;

    void Start()
    {
        gameObject.transform.parent = GameObject.Find("Map").transform;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * velocity);

        time += Time.deltaTime;

        if (time >= temp + 2)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Transparent")
        {
            // print(other.name);
            Destroy(gameObject);
        }
    }
}
