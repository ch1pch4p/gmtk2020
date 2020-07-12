using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionScript : MonoBehaviour
{

    protected CatScript cat;
    protected CatControllerScript controller;

    // Start is called before the first frame update
    public virtual void Act()
    {
        //stay idle
    }

    public virtual void Start()
    {
        cat = GetComponent<CatScript>();
    }

}
