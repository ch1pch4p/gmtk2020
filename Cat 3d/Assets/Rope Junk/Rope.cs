using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Rope : MonoBehaviour
{
    public int segments;
    public int length;
    public Transform target;
    public GameObject nodeType;

    protected float[] BonesLength;
    protected float CompleteLength;
    protected Transform[] Bones;
    protected Vector3[] Positions;
    protected Vector3[] Velocities;
    protected Vector3[] Acceleration;

    protected LineRenderer lineRenderer;


    void Init()
    {
        Bones = new Transform[segments + 1];
        Positions = new Vector3[segments + 1];
        Velocities = new Vector3[segments + 1];
        BonesLength = new float[segments];
        CompleteLength = 0;
        var head = this.gameObject.transform;
        if (head.childCount > 0)
        {
            for (int i = head.childCount - 1; i >= 0; i--)
            {
                var child = head.GetChild(i);
                DestroyImmediate(child.gameObject);

            }
            head.DetachChildren();
        }

        //create bones
        //Bones[0] = this.gameObject.transform;
        for (int i = 0; i < Bones.Length; i++)
        {

            var node = new GameObject("node(" + (i) + ")");
            node.transform.parent = head;
            node.transform.position = head.transform.position; ;
            if(i > 0)
                node.transform.position = (head.position + (target.position - head.position).normalized * Mathf.Floor(length / segments));
            Bones[i] = node.transform;
            CompleteLength += (node.transform.position - head.position).magnitude;
            if (i > 0) { 
                BonesLength[i - 1] = (node.transform.position - head.position).magnitude;
            }
            head = node.transform;
        }
        //initialize data

        //start line renderer
        lineRenderer = this.gameObject.GetComponent<LineRenderer>();
        if(lineRenderer == null)
            lineRenderer = this.gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = segments + 1;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake()
    {
       Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        ResolveIK();
    }

    private void ResolveIK()
    {
        if(target == null)
            return;

        if(BonesLength.Length != segments)
        {
            Init();
        }

        //get position
        for(int i = 0; i < Bones.Length; i++)
        {
            Positions[i] = Bones[i].position;
        }

        //calculation
        if((target.position - Bones[0].position).sqrMagnitude >= CompleteLength * CompleteLength)
        {
            //stretch
            var direction = (target.position - Positions[0]).normalized;
            //set everything after root;
            for (int i = 1; i < Positions.Length; i++)
                Positions[i] = Positions[i - 1] + direction * BonesLength[i - 1];
        }

        //set position
        for(int i = 1; i < Bones.Length; i++)
        {
            Bones[i].position = Positions[i];
            //if(i > 0)
                //Debug.DrawLine(Bones[i-1].position, Bones[i].position, Color.cyan, 60f, false);
        }
        lineRenderer.SetPositions(Positions);

    }

    void OnDrawGizmos()
    {
        var current = this.transform;
        if(Bones != null)
        {
            ResolveIK();
            for (int i = 0; i < segments && current != null && current.parent != null; i++)
            {
                var scale = Vector3.Distance(current.position, current.parent.position) * 0.1f;
                current = current.parent;
            }
        }
    }
}
