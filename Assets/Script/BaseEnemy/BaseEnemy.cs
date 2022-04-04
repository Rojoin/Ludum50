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
    
    public GameObject healthOrb;
    public delegate void EnemyDead(Vector3 position);
    public static event EnemyDead OnEnemyDead;
    public delegate void RequestingEnemyDamaged();
    public static event RequestingEnemyDamaged onRequestingEnemyDamaged;
    public delegate void RequestingEnemyDeath();
    public static event RequestingEnemyDeath onRequestingEnemyDeath;
    
   

    void Start()
    {
      enemy = PoolReferenceManager.staticPlayer.transform;
       
    }
    public override void OnStay()
    {

    }
    public override void OnWalking()
    {
        if (agent.stoppingDistance > Vector3.Distance(transform.position, enemy.position)) 
            myState = State.Attacking;
        else
        if(!agent.isStopped)agent.SetDestination(enemy.position);

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
        myState = State.Hurt;
        lifePoints -= damage;
        onRequestingEnemyDamaged?.Invoke();
        if (lifePoints > 0)
            myState = State.Walking;
        else
        {
            myState = State.Die;
            onRequestingEnemyDeath?.Invoke();
        }
    }
    public override IEnumerator OnDie()
    {
        agent.isStopped = true;
        yield return new WaitForSeconds(deadAnimTime);

        //Instantiate(healthOrb, gameObject.transform.position, Quaternion.identity);
      

        OnEnemyDead?.Invoke(transform.position);
        
        currentCoroutine = null;
        Destroy(gameObject);

        
        
    }
}
