using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiredBehaviroScript : CatBehaviorScript
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Act()
    {
        catScript.Exhaustion -= 1 * Time.fixedDeltaTime;
        if (catScript.Exhaustion <= 0)
        {

        }
    }
}
