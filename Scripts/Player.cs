using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public Transform rotorX, rotorY, cam;
    public Vector2 sensitivity;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        UpdateCamera();
        rb.AddForce(speed * Time.deltaTime * (
            rotorX.forward * Input.GetAxis("Vertical") +
            rotorX.right * Input.GetAxis("Horizontal")
        ));
    }
    void UpdateCamera()
    {
        rotorX.position = Vector3.Lerp(rotorX.position, transform.position, 10f * Time.deltaTime);
        rotorX.eulerAngles += new Vector3(0, Input.GetAxis("Mouse X") * sensitivity.x);
        //rotorY.localEulerAngles = new Vector3(rotorY.localEulerAngles + Input.GetAxis("Mouse Y") * sensitivity.x ,0);
    }
}
