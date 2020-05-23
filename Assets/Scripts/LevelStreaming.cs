using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStreaming : MonoBehaviour
{
    // public GameObject player;
    [Header("Room to load")]
    public GameObject lRoom1;
    public GameObject lRoom2;
    public GameObject lRoom3;
    [Header("Room to unload")]
    public GameObject uRoom1;
    public GameObject uRoom2;
    public GameObject uRoom3;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            lRoom1.SetActive(true);
            lRoom2.SetActive(true);
            lRoom3.SetActive(true);
            uRoom1.SetActive(false);
            uRoom2.SetActive(false);
            uRoom3.SetActive(false);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(uRoom1.transform.position, 1);
        Gizmos.DrawWireSphere(uRoom2.transform.position, 1);
        Gizmos.DrawWireSphere(uRoom3.transform.position, 1);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(lRoom1.transform.position, 1);
        Gizmos.DrawWireSphere(lRoom2.transform.position, 1);
        Gizmos.DrawWireSphere(lRoom3.transform.position, 1);
    }
}
