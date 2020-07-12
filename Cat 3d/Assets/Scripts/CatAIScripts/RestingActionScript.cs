using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestingActionScript : ActionScript
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        //cat resting is uninteruptable
        cat.Controller.Lock();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Act()
    {
        //TODO adjust for exhaustion timing and move cat out of tired phase
        cat.Exhaustion -= 1 * Time.fixedDeltaTime;
        if (cat.Exhaustion <= 0)
        {
            //when fully rested cat can then change action
            cat.Controller.Unlock();
        }
    }
}
