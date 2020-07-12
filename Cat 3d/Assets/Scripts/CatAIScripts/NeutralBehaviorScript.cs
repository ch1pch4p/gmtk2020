using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralBehaviorScript : CatBehaviorScript
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
        rb = gameObject.GetComponent<Rigidbody>();
        speed = catScript.Spd;
        Debug.Log("Starting Behavior");
        StartCoroutine(Idle());
    }

    // Update is called once per frame
    public override void Act()
    {
        if (state == State.Walking)
        {
            rb.velocity = direction * speed * Time.fixedDeltaTime * 10;
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
