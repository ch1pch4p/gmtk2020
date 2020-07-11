using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;

    //stats go here
    [SerializeField] private float str;
    [SerializeField] private float end;
    [SerializeField] private float foc;
    [SerializeField] private float anger;
    [SerializeField] private float perc;
    [SerializeField] private float spd;

    private float excitement;
    private float exhaustion;
    private float irritability;

    CatControllerScript controller;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        controller = new CatControllerScript(str, end, foc, anger, perc, spd, rb);
    }

    // Update is called once per frame
    void Update()
    {
        //update mood
        //check for state changes based on mood
    }
}
