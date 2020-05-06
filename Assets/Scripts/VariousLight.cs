using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariousLight : MonoBehaviour
{
    public float varMin = 0.1f;
    public float varMax = 0.3f;

    float intensity = 0.0f;


    void Start()
    {
        intensity = GetComponent<Light>().intensity;
    }

    void Update()
    {
        float x = Random.Range(varMin, varMax);

        GetComponent<Light>().intensity = intensity * x * 2;
    }
}
