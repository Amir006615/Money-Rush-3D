using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpeed : MonoBehaviour
{
    public float cameraSpeed = 10;

    // Update is called once per frame
    void Update()
    {
        // move forward
        transform.position += Vector3.forward * cameraSpeed * Time.deltaTime;
    }
}
