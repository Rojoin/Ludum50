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
    public delegate Transform EnemyDead(Transform position);
    public static event EnemyDead OnEnemyDead;
    public delegate void RequestingEnemyDamaged();
    public static event RequestingEnemyDamaged onRequestingEnemyDamaged;
    public delegate void RequestingEnemyDeath();
    public static event RequestingEnemyDeath onRequestingEnemyDeath;
    
   

    Transform drop;
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
        drop = OnEnemyDead?.Invoke(transform);
        agent.isStopped = true;
        yield return new WaitForSeconds(deadAnimTime);
        if(drop != null)
        {
        drop.gameObject.SetActive(true);
        drop.parent=null;
        drop = null;
        }
            
        //Instantiate(healthOrb, gameObject.transform.position, Quaternion.identity);
      

        
        currentCoroutine = null;
        Destroy(gameObject);

        
        
    }
    public void SetReference(Transform player) 
        {
            enemy = player;
        }
    
}