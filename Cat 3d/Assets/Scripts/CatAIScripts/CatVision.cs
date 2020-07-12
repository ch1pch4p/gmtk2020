using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatVision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Item.currentlyHeldItem == null)
        {
            return;
        }

        Vector3 targetDir = Item.currentlyHeldItem.transform.position - transform.position;
        float itemToCatAngle = Vector3.Angle(targetDir, transform.forward);
        if (itemToCatAngle < 70f)
        {
            // The step size is equal to speed times frame time.
            float singleStep = 5.0f * Time.deltaTime;

            // Rotate the forward vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDir, singleStep, 0.0f);

            // Draw a ray pointing at our target in
            Debug.DrawRay(transform.position, newDirection, Color.red);

            // Calculate a rotation a step closer to the target and applies rotation to this object
            transform.rotation = Quaternion.LookRotation(newDirection);
            GetComponent<Rigidbody>().AddForce(targetDir);
        }
    }
}
