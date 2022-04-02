using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class meleeWeapon : MonoBehaviour
{
    [SerializeField] float timeUntilAttack = 0.1f; 
    [SerializeField] float activeTimeAttack = 0.5f; 
    [SerializeField] BoxCollider boxCollider;
    public InputAction shoot;
    // Start is called before the first frame update
    void Start()
    {
        
    }



    void OnShoot()
    {
        
        StartCoroutine(activateMelee());
    }

        IEnumerator activateMelee()
        {
            yield return new WaitForSeconds(timeUntilAttack);
            boxCollider.gameObject.SetActive(true);
            Debug.Log("Se activo la hitbox");
            yield return new WaitForSeconds(activeTimeAttack);
            boxCollider.gameObject.SetActive(false);
        }
        
    // Update is called once per frame
    void Update()
    {
        
    }
}
