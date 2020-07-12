using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    private Vector3 checkpoint;
    [SerializeField]
    private int steps;
    private Rigidbody rb;
    [SerializeField]
    // Start is called before the first frame update
    void Start()
    {
        checkpoint = Vector3.zero + transform.position;
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            respawn();
        }
    }

    private void FixedUpdate()
    {
        
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 20f))
            {
                if(hit.distance < 2f && (transform.position - checkpoint).magnitude > steps)
                    checkpoint = Vector3.zero + transform.position;
            } else {
                if (rb.velocity.y < -15f)
                    respawn();
            }
    }

    public void respawn()
    {
        transform.position = checkpoint;
        rb.velocity = Vector3.zero;
    }
}
