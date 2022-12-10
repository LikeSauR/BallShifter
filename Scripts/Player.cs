using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public Transform rotorX, rotorY, cam;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        
        rb.AddForce(speed * Time.deltaTime * (
            rotorX.forward * Input.GetAxis("Vertical") + 
            rotorX.right * Input.GetAxis("Horizontal")
        ));
    }
}
