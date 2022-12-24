using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : DetectorTrigger
{
    Rigidbody rb;
    public float speed;
    public Transform rotorX, rotorY, cam;
    public Vector2 sensitivity;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        UpdateCamera();
        rb.velocity = speed * Time.deltaTime * (
            rotorX.forward * Input.GetAxis("Vertical") +
            rotorX.right * Input.GetAxis("Horizontal")
            ) + new Vector3(0, rb.velocity.y);
    }
    void UpdateCamera()
    {
        rotorX.position = Vector3.Lerp(rotorX.position, transform.position, 10f * Time.deltaTime);
        rotorX.eulerAngles += new Vector3(0, Input.GetAxis("Mouse X") * sensitivity.x);
        rotorY.localEulerAngles = new Vector3(rotorY.localEulerAngles.x + Input.GetAxis("Mouse Y") * sensitivity.x ,0);
    }
}
