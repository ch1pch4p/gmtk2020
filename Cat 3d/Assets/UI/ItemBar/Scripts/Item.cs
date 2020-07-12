using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public static GameObject currentlyHeldItem;
    // Start is called before the first frame update
    void Start()
    {
    }

    public abstract void ClickedItem();

    public abstract void HoldingItem();

    public abstract void DroppedItem();

    void FixedUpdate()
    {
        if (currentlyHeldItem == null)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            DroppedItem();
            currentlyHeldItem = null;
            return;
        }

        HoldingItem();
    }
}
