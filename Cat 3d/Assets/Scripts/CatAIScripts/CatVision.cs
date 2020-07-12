using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatVision : MonoBehaviour
{
    float maxSpeed = 10f;
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

        Vector3 targetDir = Item.currentlyHeldItem.transform.position - transform.position + Vector3.up;
        float itemToCatAngle = Vector3.Angle(targetDir, transform.forward);
        if (itemToCatAngle < 70f)
        {
            // The step size is equal to speed times frame time.
            float singleStep = 5.0f * Time.deltaTime;

            // Rotate the forward vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDir, singleStep, 0.0f);

            // Draw a ray pointing at our target in
            Debug.DrawRay(transform.position, newDirection, Color.red);

            //Quaternion dir = Quaternion.LookRotation(newDirection, Vector3.up);
            //newDirection = dir * Vector3.forward;

            // Calculate a rotation a step closer to the target and applies rotation to this object
            Physics.Raycast(transform.position, -1 * transform.up, out RaycastHit hit);
            Debug.Log("Cat-to-Surface normal: " + hit.normal);
            transform.rotation = Quaternion.LookRotation(newDirection, hit.normal);
            GetComponent<Rigidbody>().AddForce(transform.forward * 100);
            Vector3 velocityToClamp = new Vector3(GetComponent<Rigidbody>().velocity.x, 0, GetComponent<Rigidbody>().velocity.z);
            Vector3 clampedVelocity = Vector3.ClampMagnitude(velocityToClamp, maxSpeed);
            GetComponent<Rigidbody>().velocity = new Vector3(clampedVelocity.x, GetComponent<Rigidbody>().velocity.y, clampedVelocity.z);
        }
    }
}
