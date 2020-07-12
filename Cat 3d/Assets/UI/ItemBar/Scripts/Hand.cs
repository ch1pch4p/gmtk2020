using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public GameObject hand;
    public GameObject cursor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get real world point to drop object
        Ray ray = Camera.main.ScreenPointToRay(cursor.transform.position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            //draw invisible ray cast/vector
            Debug.DrawLine(ray.origin, hit.point);
            //log hit area to the console
            Debug.Log(hit.point);
            hand.transform.position = hit.point + (hit.normal);
        }
    }
}
