using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MillingActionsScript : ActionScript
{
    private Rigidbody rb;
    // Start is called before the first frame update
    private Vector3 direction;
    private float speed;

    private IEnumerator coroutine;

    enum State
    {
        Idle,
        Walking
    }

    private State state;

    public override void Start()
    {
        base.Start();
        rb = cat.Rb;
        speed = cat.Spd;
        Debug.Log("Starting Behavior");
        StartCoroutine(Idle());
    }

    // Update is called once per frame
    public override void Act()
    {
        if (state == State.Walking)
        {
            float singleStep = 5.0f * Time.deltaTime;

            // Rotate the forward vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, singleStep, 0.0f);

            // Draw a ray pointing at our target in
            Debug.DrawRay(transform.position, newDirection, Color.red);

            //Quaternion dir = Quaternion.LookRotation(newDirection, Vector3.up);
            //newDirection = dir * Vector3.forward;

            // Calculate a rotation a step closer to the target and applies rotation to this object
            Physics.Raycast(transform.position, -1 * transform.up, out RaycastHit hit);
            Debug.Log("Cat-to-Surface normal: " + hit.normal);
            transform.rotation = Quaternion.LookRotation(newDirection, hit.normal);
            rb.AddForce(transform.forward * 100);
            Vector3 velocityToClamp = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            Vector3 clampedVelocity = Vector3.ClampMagnitude(velocityToClamp, speed);
            rb.velocity = new Vector3(clampedVelocity.x, rb.velocity.y, clampedVelocity.z);
        }
    }

    IEnumerator Idle()
    {
        Debug.Log(state);
        yield return new WaitForSeconds(Random.Range(0, 10));

        ChangeDirection();
        state = State.Walking;

        StartCoroutine(Walking());
    }

    IEnumerator Walking()
    {
        Debug.Log(state);
        Debug.Log(direction);
        int turns = Random.Range(1, 2);
        //TODO fix to make turns work
        for (int i = 0; i < turns; i++)
        {
            yield return new WaitForSeconds(Random.Range(0, 10));

            ChangeDirection();
        }

        state = State.Idle;
        StartCoroutine(Idle());
    }

    private void ChangeDirection()
    {
        direction = Random.insideUnitCircle.normalized;
        direction.z = direction.y;
        direction.y = 0;
        Quaternion temp = Quaternion.LookRotation(direction, Vector3.up);
        direction = temp * this.transform.forward;
    }
}
