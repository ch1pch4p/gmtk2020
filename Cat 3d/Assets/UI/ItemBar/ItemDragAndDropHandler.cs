using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragAndDropHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public RectTransform itemPanel;
    public GameObject realWorldObject;
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!RectTransformUtility.RectangleContainsScreenPoint(itemPanel, Input.mousePosition))
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
                realWorldObject = GameObject.Instantiate(realWorldObject);
                realWorldObject.transform.position = hit.point;
                Debug.Log("Dropped object at: " + hit.point);
            }

        }
        transform.localPosition = Vector3.zero;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
