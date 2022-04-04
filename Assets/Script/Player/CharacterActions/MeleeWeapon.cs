using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MeleeWeapon : MonoBehaviour
{
    public Collider col;
    public int damage;
    bool isAttacking;
    [SerializeField] float timeUntilAttack = 0.1f; 
    [SerializeField] float activeTimeAttack = 0.5f; 
    public delegate void RequestingMeleeAttack();
    public static event RequestingMeleeAttack OnRequestingMeleeAttack;

    public void meleeAttack()
    {
        if(!isAttacking)
        StartCoroutine(activateMelee());
    }
    public LayerMask hitable;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("aca");
            other.GetComponent<Killable>().TakeDamage(damage);

        }
    }
    IEnumerator activateMelee()
    {
        isAttacking = true;
        yield return new WaitForSeconds(timeUntilAttack);
        col.enabled = true;
        OnRequestingMeleeAttack?.Invoke();
        yield return new WaitForSeconds(activeTimeAttack);
        col.enabled = false;
        isAttacking = false;
    }
}
