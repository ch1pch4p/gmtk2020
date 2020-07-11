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

    public CatControllerScript(float str, float end, float foc, float anger, float perc, float spd, Rigidbody rb)
    {
        this.str = str;
        this.end = end;
        this.foc = foc;
        this.anger = anger;
        this.perc = perc;
        this.spd = spd;
        this.rb = rb;

        currentBehavior = new NeutralBehaviorScript(this.spd, this.rb);
        currentBehavior.InitializeBehavior();
    }


    private void FixedUpdate()
    {
        currentBehavior.Act();
    }
}
