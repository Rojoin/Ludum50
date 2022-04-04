using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAttack : MonoBehaviour
{
    public int damage;
    public float attackCooldown; // cooldown entre ataques
    public float timeWaitingToTryHit; // tiempo antes de intentar pegar el golpe
    public float timeTryingHit; // tiempo en el que el golpe puede hacer efecto
    public float timeRestToEnd; // tiempo despues de intentar golpear
    public bool endAttack;
    public bool canAttack;
    public GameObject target = null;
    protected virtual void Start()
    {
        canAttack = true;
        endAttack = false;
    }

    public bool DoAttack()
    {
        if(canAttack) StartCoroutine(Attacking());
        return endAttack;
    }
    public abstract IEnumerator Attacking();
}
