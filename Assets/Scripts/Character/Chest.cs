using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Transform body;
    public Transform parent;

    void Update()
    {
        transform.eulerAngles = new Vector3(0, body.rotation.y, 0);
        transform.position = parent.position;
    }
}
