using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BaseEnemy : StateEmemy
{
    public int lifePoints;
    public NavMeshAgent agent;
    public Transform enemy;
    public BaseAttack attack;
    void Start()
    {
    }
    public override void OnStay()
    {

    }
    public override void OnWalking()
    {
        agent.SetDestination(enemy.position);
        if (agent.stoppingDistance > Vector3.Distance(transform.position, enemy.position)) 
            myState = State.Attacking;
    }
    public override void OnAttaking()
    {
        Debug.Log("Attack");
    }
    public override void OnHurt()
    {

    }
    public override void OnDie()
    {

    }
}
