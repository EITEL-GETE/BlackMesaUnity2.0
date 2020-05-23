using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeMe : MonoBehaviour
{
    public GameObject messageGO;

    private GameObject playerGO;

    void Start()
    {
        messageGO.SetActive(false);
        playerGO = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision avec:" + other.gameObject.name);
        if (other.gameObject == playerGO)
        {
            messageGO.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject == playerGO)
        {
            messageGO.SetActive(false);
        }
        
    }
}
