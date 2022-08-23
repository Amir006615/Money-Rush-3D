using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 lastMousePos;
    public float sensitivity = .16f, clampDelta = 42f;
    // Update is called once per frame

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
            // move left and right 
            if (Input.GetMouseButton(0))
            {
                Vector3 vector = lastMousePos - Input.mousePosition;
                lastMousePos = Input.mousePosition;
                vector = new Vector3(vector.x, 0, 0);

                Vector3 moveForce = Vector3.ClampMagnitude(vector, clampDelta);
                rb.AddForce(-moveForce * sensitivity - rb.velocity / 5f, ForceMode.VelocityChange);
            }
    }
}
