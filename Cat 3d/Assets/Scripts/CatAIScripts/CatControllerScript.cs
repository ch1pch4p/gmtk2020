using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CatControllerScript : MonoBehaviour
{

    CatScript cat;

    private bool actionLocked = false;
    enum CatActions
    {
        Resting,
        Milling,
        Pouncing,
        Sprinting
    }
    
    private ActionScript currentAction;
    private ActionScript[] catActions = new ActionScript[5];
    private float[] ActionWeights = new float[4] { 0f, 100f, 15f, 100f};

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


        catActions[(int)CatActions.Resting] = gameObject.AddComponent<RestingActionScript>();
        catActions[(int)CatActions.Milling] = gameObject.AddComponent<MillingActionsScript>();
        catActions[(int)CatActions.Pouncing] = gameObject.AddComponent<PouncingActionScript>();
        catActions[(int)CatActions.Sprinting] = gameObject.AddComponent<CatVision>();
        currentAction = catActions[(int)CatActions.Milling];
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
            //TODO update weights

            UpdateWeights();

            currentAction = catActions[Choose(ActionWeights)];
        }
        
        currentAction.Act();
    }

    private void UpdateWeights()
    {
    }

    int Choose(float[] probs)
    {

        float total = 0;

        foreach (float elem in probs)
        {
            total += elem;
        }

        float randomPoint = UnityEngine.Random.value * total;

        for (int i = 0; i < probs.Length; i++)
        {
            if (randomPoint < probs[i])
            {
                return i;
            }
            else
            {
                randomPoint -= probs[i];
            }
        }
        return probs.Length - 1;
    }

}
