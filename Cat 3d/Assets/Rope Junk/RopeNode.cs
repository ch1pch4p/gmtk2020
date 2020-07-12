using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeNode
{
    public RopeNode previous;
    public RopeNode next;
    public GameObject gameObject;

    RopeNode(float damping)
    {
        gameObject = new GameObject();
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.drag = Mathf.Abs(damping);
    }
    RopeNode()
    {
        gameObject = new GameObject();
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
    }

}
