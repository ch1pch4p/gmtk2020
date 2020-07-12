using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeNew : MonoBehaviour
{

    public int segments;
    public int length;
    public Transform target;
    private RopeNode[] nodes;

    private void Start()
    {
        
    }

    private void Awake()
    {

    }

    private void Init()
    {
        nodes = new RopeNode[segments + 1];

    }

    private void Update()
    {
       
    }

    private void LateUpdate()
    {
       
    }
}
