using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotation : MonoBehaviour
{
    public Camera characterCamera;
    public float cameraDistance = 0.4f;
    public LayerMask cameraMask;
    public float zoomSpeed = 1.0f;
    [Space]
    public float moveIntensity = 1.0f;

    bool isWalled = false;
    bool isNear = false;
    float scale = 1.0f;
    float rScale = 1.0f;

    void Update()
    {
        transform.localEulerAngles = new Vector3(-Input.GetAxis("Vertical") * moveIntensity, 0, 0);

        isWalled = Physics.CheckSphere(characterCamera.transform.position, cameraDistance, cameraMask);

        isNear = Physics.CheckSphere(characterCamera.transform.position, cameraDistance / 2, cameraMask);

        transform.localScale = new Vector3(rScale, rScale, rScale);

        rScale = scale;// Time.deltaTime * (scale - rScale) * zoomSpeed;

        if (isWalled && isNear)
        {
            if (scale > 0.3f)
            {
                scale -= Time.deltaTime * zoomSpeed;
            }
            else
            {
                scale = 0.3f;
            }
        }

        if (!isWalled && !isNear)
        {
            if (scale < 1)
            {
                scale += Time.deltaTime * zoomSpeed;
            }
            else
            {
                scale = 1;
            }
        }
    }
}
