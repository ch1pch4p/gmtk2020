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

    public NeutralBehaviorScript(float speed, Rigidbody rb)
    {
        this.speed = speed;
        this.rb = rb;
    }

    enum State
    {
        Idle,
        Walking
    }

    private State state;

    public override void InitializeBehavior()
    {
        coroutine = Idle();
        StartCoroutine(coroutine);
    }

    // Update is called once per frame
    public override void Act()
    {
        if (state == State.Walking)
        {
            rb.velocity = direction * speed * Time.fixedDeltaTime;
        }
    }

    IEnumerator Idle()
    {
        yield return new WaitForSeconds(Random.Range(0, 10));

        ChangeDirection();
        state = State.Walking;

        coroutine = Walking();
        StartCoroutine(coroutine);
    }

    IEnumerator Walking()
    {
        int turns = Random.Range(0, 2);
        for (int i = 0; i < turns; i++)
        {
            yield return new WaitForSeconds(Random.Range(0, 10));

            ChangeDirection();
        }

        state = State.Idle;
        coroutine = Idle();
        StartCoroutine(coroutine);
    }

    private void ChangeDirection()
    {
        direction = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1)).normalized;
    }
}
