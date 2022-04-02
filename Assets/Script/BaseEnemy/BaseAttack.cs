using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttack : MonoBehaviour
{
    public Collider col;
    public int damage;
    public float attackCooldown; // cooldown entre ataques
    public float timeWaitingToTryHit; // tiempo antes de intentar pegar el golpe
    public float timeTryingHit; // tiempo en el que el golpe puede hacer efecto
    public float timeRestToEnd; // tiempo despues de intentar golpear
    public bool endAttack;
    public bool canAttack;
    GameObject target = null;
    void Start()
    {
        col.enabled = false;
        canAttack = true;
        endAttack = false;
    }

    public bool DoAttack()
    {
        if(canAttack) StartCoroutine(Attacking());
        return endAttack;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            target = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (target != null) target = null;
        }
    }
    public virtual IEnumerator Attacking()
    {
        endAttack = false;
        canAttack = false;
        yield return new WaitForSeconds(timeWaitingToTryHit);
        col.enabled = true;
        yield return new WaitForSeconds(timeTryingHit);
        col.enabled = false;
        if(target != null) target.GetComponent<PlayerHP>().TakeDamage(damage);
        yield return new WaitForSeconds(timeRestToEnd);
        endAttack = true;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
}
}
