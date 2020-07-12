﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour
{

    //stats go here
    [SerializeField] private float str = 10;
    [SerializeField] private float end = 10;
    [SerializeField] private float foc = 10;
    [SerializeField] private float anger = 10;
    [SerializeField] private float perc = 10;
    [SerializeField] private float spd = 10;

    public float Exhaustion { get; set; }
    public float Spd { get => spd; set => spd = value; }
    public float Excitement { get; set; }
    public float Irritability { get; set; }
    public Rigidbody Rb { get; set; }
    public CatControllerScript Controller { get; set; }
    public GameObject Target { get; set; }

    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Controller = gameObject.AddComponent<CatControllerScript>();
        //Temp Code should change target in sensing scripts

        Target = Item.currentlyHeldItem;
    }

    // Update is called once per frame
    void Update()
    {
        //update mood
        //check for state changes based on mood
    }
}
