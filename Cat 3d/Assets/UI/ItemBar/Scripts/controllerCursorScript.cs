﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerCursorScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.position = new Vector3(Mathf.Clamp(transform.position.x + horizontal*5, 0, Screen.width),
                                         Mathf.Clamp(transform.position.y + vertical*5, 0, Screen.height));
    }
}
