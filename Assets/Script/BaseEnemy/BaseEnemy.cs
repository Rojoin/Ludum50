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
        if (agent.stoppingDistance > Vector3.Distance(transform.position, enemy.position)) 
            myState = State.Attacking;
        else
            agent.SetDestination(enemy.position);

    }
    public override void OnAttaking()
    {
        if(attack.DoAttack())
        {
            myState = State.Walking;
        }
    }
    public override void OnHurt(int damage)
    {
        lifePoints -= damage;
        if (lifePoints > 0)
            myState = State.Walking;
        else
            myState = State.Die;
    }
    public override void OnDie()
    {
        Destroy(gameObject);
    }
}
