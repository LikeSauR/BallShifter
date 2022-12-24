using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Portal : MonoBehaviour
{
    public Vector3 to, rotation;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Portable p))
        {
            Transform t = collision.transform;
            t.position = to;
            t.eulerAngles = rotation;
        }
    }
}