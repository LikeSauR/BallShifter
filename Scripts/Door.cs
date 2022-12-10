using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float seconds;
    //[HideInInspector] 
    public float target, progress;
    [System.Serializable]
    public class Objective
    {
        public Transform obj;
        public Vector3 posA, posB;
    }
    public Objective[] objectives;
    void Update()
    {
        progress = Mathf.Lerp(progress, target, Time.deltaTime / seconds);
        foreach (var o in objectives)
        {
            o.obj.position = Vector3.Lerp(o.posA, o.posB, progress);
        }
    }
    void OnDrawGizmos()
    {
        if (objectives != null)
        foreach (var o in objectives)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(o.posA, .25f);
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(o.posB, .25f);
        }
    }
}
