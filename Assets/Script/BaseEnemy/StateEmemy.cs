using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateEmemy : MonoBehaviour
{

    public enum State
    {
        Stay,Walking,Attacking,Hurt,Die
    };

    public State myState;
    public Animator animator;
    protected Coroutine currentCoroutine;
    public float deadAnimTime;
    State lastState;
    void Start()
    {
        currentCoroutine = null;
        myState = State.Walking;
        changeAnimationState(State.Walking);
    }


    private void Update()
    {
        switch(myState)
        {
            case State.Stay:
                if(State.Stay != lastState)changeAnimationState(State.Stay);
                OnStay();
                break;
            case State.Walking:
                if(State.Walking != lastState)changeAnimationState(State.Walking);
                OnWalking();
                break;
            case State.Attacking:
                if(State.Attacking != lastState)changeAnimationState(State.Attacking);
                OnAttaking();
                break;
            case State.Hurt:
                break;
            case State.Die:
                if(State.Die != lastState)changeAnimationState(State.Die);
                if(currentCoroutine == null)currentCoroutine= StartCoroutine("OnDie");
                break;
        }
    }
    void changeAnimationState(State myState)
    {
        animator.SetInteger("state",(int)myState);
        lastState = myState;
        animator.SetTrigger("start");
    }
    public abstract void OnStay();
    public abstract void OnWalking();
    public abstract void OnAttaking();
    public abstract void OnHurt(int damage);
    public abstract IEnumerator OnDie();
}
