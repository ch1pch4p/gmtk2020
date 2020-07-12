using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppableItem : Item
{
    public GameObject realWorldItem;
    // Start is called before the first frame update
    void Start()
    {
        realWorldItem = Instantiate(realWorldItem);
    }

    public override void ClickedItem()
    {
        Item.currentlyHeldItem = realWorldItem;
    }

    public override void HoldingItem()
    {
        // Get real world point to drop object
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            //draw invisible ray cast/vector
            Debug.DrawLine(ray.origin, hit.point);
            //log hit area to the console
            Debug.Log(hit.point);
            currentlyHeldItem.transform.position = hit.point;
        }
    }

    public override void DroppedItem()
    {
        currentlyHeldItem.transform.position = Vector3.zero;
    }
}
