using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;

    //stats go here
    [SerializeField] private float str = 10;
    [SerializeField] private float end = 10;
    [SerializeField] private float foc = 10;
    [SerializeField] private float anger = 10;
    [SerializeField] private float perc = 10;
    [SerializeField] private float spd = 10;

    private float excitement;
    private float exhaustion;
    private float irritability;


    CatControllerScript controller;

    public float Exhaustion { get => exhaustion; set => exhaustion = value; }
    public float Spd { get => spd; set => spd = value; }
    public float Excitement { get => excitement; set => excitement = value; }
    public float Irritability { get => irritability; set => irritability = value; }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        controller = gameObject.AddComponent<CatControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //update mood
        //check for state changes based on mood
    }
}
