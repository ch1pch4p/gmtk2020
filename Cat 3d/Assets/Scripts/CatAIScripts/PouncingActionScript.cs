using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouncingActionScript : ActionScript
{

    bool pounced = false;
    private bool isPreppingPounce = false;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        cat.Controller.Lock();
        StartCoroutine(PrepPounce());
    }

    public override void Act()
    {
        if (pounced && cat.Rb.velocity.y <= 0 && cat.Grounded)
        {
            cat.Controller.Unlock();
            pounced = false;
        }
        else if(!isPreppingPounce)
        {
            cat.Controller.Lock();
            isPreppingPounce = true;
            StartCoroutine(PrepPounce());
        }
    }

    IEnumerator PrepPounce()
    {
        yield return new WaitForSeconds(2.0f);
        isPreppingPounce = false;
        pounced = true;
        cat.Rb.AddForce((cat.Target.transform.position - transform.position).normalized * cat.Spd, ForceMode.Impulse);
        cat.Rb.AddForce(Vector3.up * cat.Str, ForceMode.Impulse);
        cat.Controller.Unlock();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
