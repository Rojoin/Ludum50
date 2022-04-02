using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class inputSystem : MonoBehaviour
{
    public InputAction attack;
    public InputAction recharge;
    public InputAction scroll;
    
    [SerializeField] SwitchingWeapons switchingWeapons;
    [SerializeField] GunRaycast gun;
    [SerializeField] MeleeWeapon melee;
 
    [SerializeField] GameObject[] weapons;
    const int slot1 = 0; //Arma Pistola
    const int slot2 = 1; //Arma Melee

    void OnAttack()
    {
        switch(switchingWeapons.weaponIndex)
        {
            case slot1:
                gun.Shooting();
                break;
            case slot2:
                melee.meleeAttack();
                break;
        }

    }
    void OnScroll()
    {
        if(!gun.myAmmo.IsReloading) switchingWeapons.SelectWeapon();
    }
  
}
