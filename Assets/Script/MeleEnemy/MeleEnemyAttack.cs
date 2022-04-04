using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleEnemyAttack : BaseAttack
{
    public delegate void RequestingEnemyMeleeAttack();
    public static event RequestingEnemyMeleeAttack OnRequestingEnemyMeleeAttack;
    public Collider col;
    protected override void Start()
    {
        base.Start();
        col.enabled = false;
    }
    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            target = other.gameObject;
        }
    }
    public virtual void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (target != null) target = null;
        }
    }
    public override IEnumerator Attacking()
    {
        endAttack = false;
        canAttack = false;
        yield return new WaitForSeconds(timeWaitingToTryHit);
        col.enabled = true;
        yield return new WaitForSeconds(timeTryingHit);
        col.enabled = false;
        if (target != null) target.GetComponent<PlayerHP>().TakeDamage(damage);
        OnRequestingEnemyMeleeAttack?.Invoke();
        yield return new WaitForSeconds(timeRestToEnd);
        endAttack = true;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}
