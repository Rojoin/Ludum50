using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class SwitchingWeapons : MonoBehaviour
{
    public InputAction scroll;
    public GameObject weaponHolder;
    float mouseWheel =0f; 
    [SerializeField] GameObject[] weapons;
    public int weaponIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        weaponIndex = 0;
    }
   /* void OnScroll()
    {
        
       SelectWeapon();
        Debug.Log("Anda");

         
    }*/
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SelectWeapon()
    {
       mouseWheel =Mouse.current.scroll.y.ReadValue();

      if(mouseWheel !=0)
      {
        weapons[weaponIndex].SetActive(false);

        if(mouseWheel >0)
        {
            weaponIndex++;

            if(weaponIndex > weapons.Length-1)
            {
                weaponIndex= 0;
            }

        }
        else if(mouseWheel <0)
        {
             weaponIndex--;

              if(weaponIndex < 0)
            {
                weaponIndex = weapons.Length-1;
            }
        }
        weapons[weaponIndex].SetActive(true);
      }

        
        
         /*   if(weaponHolder == weapon)
            {

            if(i == selectedWeapon)
            weapon.gameObject.SetActive(true);
            else
            weapon.gameObject.SetActive(false);
            i++;
            }*/
    }
 }

