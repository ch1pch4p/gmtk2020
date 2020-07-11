using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CatControllerScript : MonoBehaviour
{
    private CatBehaviorScript currentBehavior;

    private Rigidbody rb;

    private float str;
    private float end;
    private float foc;
    private float anger;
    private float perc;
    private float spd;

    void Start()
    {
        currentBehavior = gameObject.AddComponent<NeutralBehaviorScript>();
    }


    private void FixedUpdate()
    {
        currentBehavior.Act();
    }
}
