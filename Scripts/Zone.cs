using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Zone : MonoBehaviour
{
    void Start()
    {
        var rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        var mc = GetComponent<Collider>();
        mc.isTrigger = true;
    }

    void Update()
    {
        if (isTriggered)
            IsTriggered();
        else
            IsNotTriggered();
    }

    protected virtual void IsTriggered() { }
    protected virtual void IsNotTriggered() { }

    protected List<DetectorTrigger> triggers = new List<DetectorTrigger>();
    public bool isTriggered
    {
        get { return triggers.Count > 0; }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out DetectorTrigger t))
        {
            triggers.Add(t);
            OnEnter(t);
        }
    }
    protected virtual void OnEnter(DetectorTrigger t) { }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out DetectorTrigger t))
        {
            triggers.Remove(t);
            OnExit(t);
        }
    }
    protected virtual void OnExit(DetectorTrigger t) { }
}
