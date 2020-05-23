using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagDoll : MonoBehaviour
{
    public Transform bonesParent;
    public float wait = 1;

    float time = 0;
    float temp = 0;

    void Start()
    {
        GetComponent<Animator>().enabled = false;
        Kinematicator(bonesParent);
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= temp + wait)
        {
            unKinematicator(bonesParent);
        }
    }

    void Kinematicator(Transform obj)
    {
        if (obj.childCount != 0)
        {
            for (int i = 0; i < obj.childCount; i++)
            {
                obj.GetChild(i).GetComponent<Rigidbody>().isKinematic = false;
                obj.GetChild(i).GetComponent<BoxCollider>().isTrigger = false;
                Kinematicator(obj.GetChild(i));
            }
        }
    }

    void unKinematicator(Transform obj)
    {
        if (obj.childCount != 0)
        {
            for (int i = 0; i < obj.childCount; i++)
            {
                obj.GetChild(i).GetComponent<Rigidbody>().isKinematic = true;
                obj.GetChild(i).GetComponent<BoxCollider>().isTrigger = true;
                unKinematicator(obj.GetChild(i));
            }
        }
    }
}
