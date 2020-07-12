using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CatControllerScript : MonoBehaviour
{

    CatScript cat;

    private Boolean actionLocked = false;
    enum CatActions
    {
        Resting,
        Milling,
        Sitting,
        Sprinting,
        Pouncing
    }
    
    private ActionScript currentAction;
    private ActionScript[] catActions;

    private Rigidbody rb;

    private float str;
    private float end;
    private float foc;
    private float anger;
    private float perc;
    private float spd;

    void Start()
    {
        cat = GetComponent<CatScript>();

        catActions.SetValue(gameObject.AddComponent<RestingActionScript>(), (int)CatActions.Resting);
        catActions.SetValue(gameObject.AddComponent<MillingActionsScript>(), (int)CatActions.Milling);
    }

    public void Lock()
    {
        actionLocked = true;
    }

    public void Unlock()
    {
        actionLocked = false;
    }

    private void FixedUpdate()
    {
        //TODO check if action is currently locked. if not randomly select an action and perform        
        if (!actionLocked)
        {

        }
        
        currentAction.Act();
    }
}
