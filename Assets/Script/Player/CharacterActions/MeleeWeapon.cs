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
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void meleeAttack()
    {
        if(!isAttacking)
        StartCoroutine(activateMelee());
    }
    public LayerMask hitable;
    public void OnTriggerStay(Collider other)
    {
        Debug.Log("No me falles");
        if(other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("aca");
           other.GetComponent<BaseEnemy>().lifePoints-=damage;
        }
    }
    IEnumerator activateMelee()
    {
        isAttacking = true;
        yield return new WaitForSeconds(timeUntilAttack);
        col.enabled = true;
        Debug.Log("Se activo la hitbox");
        
        yield return new WaitForSeconds(activeTimeAttack);
        col.enabled = false;
        isAttacking = false;
    }
        
    // Update is called once per frame
    void Update()
    {
        
    }
}
