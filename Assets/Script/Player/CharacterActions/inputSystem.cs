using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class inputSystem : MonoBehaviour
{
    public InputAction attack;
    public InputAction recharge;
    public InputAction scroll;
    public InputAction pause;
    public Animator animator;
   
    [SerializeField] SwitchingWeapons switchingWeapons;
    [SerializeField] GunRaycast gun;
    [SerializeField] MeleeWeapon melee;
 
    [SerializeField] GameObject[] weapons;
    const int slot1 = 0; //Arma Pistola
    const int slot2 = 1; //Arma Melee

    
    public delegate void RequestingPause();
    public static event RequestingPause OnRequestingPause;
   
   
    void OnAttack()
    {

        if(weapons[0].activeSelf)
        {
            
            gun.Shooting();

        }
        else if(weapons[1].activeSelf)
        {
            animator.SetTrigger("start");
            melee.meleeAttack();
        }
       /*switch(switchingWeapons.index)
        {
            case SwitchingWeapons.IndexWeapon.gun:
                gun.Shooting();
                Debug.Log("Gun");
                break;
            case SwitchingWeapons.IndexWeapon.katana:
                melee.meleeAttack();
                Debug.Log("Kata");
                break;
        }*/

    }
    void OnScroll()
    {
        if(!gun.myAmmo.IsReloading) switchingWeapons.SelectWeapon();
    }
  
    void OnPause()
    {
        Debug.Log("OnEscape");
        //OnRequestingPause?.Invoke();
        SceneManager.LoadScene(0);
    }

}
