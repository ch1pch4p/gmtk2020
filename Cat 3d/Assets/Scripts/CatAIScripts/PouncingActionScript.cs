using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouncingActionScript : ActionScript
{

    bool pounced = false;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        cat.Controller.Lock();
        StartCoroutine(PrepPounce());
    }

    public override void Act()
    {
        if (pounced && cat.Rb.velocity.y <=0 && cat.Grounded)
        {
            cat.Controller.Lock();
            pounced = false;
        }
    }

    IEnumerator PrepPounce()
    {
        yield return new WaitForSeconds(2.0f);
        cat.Rb.AddForce((cat.Target.transform.position - transform.position).normalized * cat.Spd, ForceMode.Impulse);
        cat.Rb.AddForce(Vector3.up * cat.Str, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
