using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera camera;
    public Transform camTransform;

    void Start()
    {
        if(camera != null)
            camTransform = camera.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(camTransform != null)
        {
            Quaternion dir = Quaternion.LookRotation(-camTransform.forward, camTransform.up);
            this.transform.forward = dir * Vector3.forward;
        }
    }
}
