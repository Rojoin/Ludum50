using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class inputSystem : MonoBehaviour
{
    public InputAction attack;
    public InputAction recharge;
    public InputAction scroll;
    public InputAction pause;
    
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
       switch(switchingWeapons.index)
        {
            case SwitchingWeapons.IndexWeapon.gun:
                gun.Shooting();
                break;
            case SwitchingWeapons.IndexWeapon.katana:
                melee.meleeAttack();
                break;
        }

    }
    void OnScroll()
    {
        if(!gun.myAmmo.IsReloading) switchingWeapons.SelectWeapon();
    }
  
    void OnPause()
    {
        Debug.Log("OnEscape");
        OnRequestingPause?.Invoke();
    }
}
