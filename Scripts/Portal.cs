using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Portal : Zone
{
    public Vector3 to, rotation;
    protected override void OnEnter(DetectorTrigger T)
    {
        Transform t = T.transform;
        t.position = to;
        t.eulerAngles = rotation;
    }
}