using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouncingActionScript : ActionScript
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        cat.Controller.Lock();
    }

    public override void Act()
    {
        StartCoroutine(PrepPounce());

    }

    IEnumerator PrepPounce()
    {
        yield return new WaitForSeconds(2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
