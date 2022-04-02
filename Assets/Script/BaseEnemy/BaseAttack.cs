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
    bool endAttack;
    bool canAttack;
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
    IEnumerator Attacking()
    {
        endAttack = false;
        canAttack = false;
        Debug.Log("start");
        yield return new WaitForSeconds(timeWaitingToTryHit);
        Debug.Log("letsSlash");
        col.enabled = true;
        yield return new WaitForSeconds(timeTryingHit);
        Debug.Log("slashed");
        col.enabled = false;
        if(target != null) target.GetComponent<PlayerHP>().TakeDamage(damage);
        yield return new WaitForSeconds(timeRestToEnd);
        Debug.Log("rest");
        endAttack = true;
        yield return new WaitForSeconds(attackCooldown);
        Debug.Log("cd");
        canAttack = true;
}
}
