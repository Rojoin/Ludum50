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
    void Start()
    {
        myState = State.Walking;
    }
    private void Update()
    {
        switch(myState)
        {
            case State.Stay:
                OnStay();
                break;
            case State.Walking:
                OnWalking();
                break;
            case State.Attacking:
                OnAttaking();
                break;
            case State.Hurt:
                OnHurt();
                break;
            case State.Die:
                OnDie();
                break;
        }
    }
    public abstract void OnStay();
    public abstract void OnWalking();
    public abstract void OnAttaking();
    public abstract void OnHurt();
    public abstract void OnDie();
}
