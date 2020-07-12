using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeNew : MonoBehaviour
{

    public int segments;
    public int length;
    public Transform target;
    public GameObject nodeType;

    protected float[] BonesLength;
    protected float CompleteLength;
    protected Transform[] Bones;
    protected Vector3[] Positions;

    protected LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Init()
    {
        Bones = new Transform[segments + 1];
        Positions = new Vector3[segments + 1];
        BonesLength = new float[segments];
        CompleteLength Length = 0;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
