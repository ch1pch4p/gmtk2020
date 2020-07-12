using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    Vector3 checkpoint;
    // Start is called before the first frame update
    void Start()
    {
        checkpoint = Vector3.zero + transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //if((transform.position - checkpoint))
    }
}
