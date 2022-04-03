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
    
    public enum IndexWeapon{gun,katana};
    public IndexWeapon index;
    
    // Start is called before the first frame update
    void Start()
    {
        index = IndexWeapon.gun;
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
        weapons[(int)index].SetActive(false);

        if(mouseWheel >0)
        {
            index++;

            if((int)index> weapons.Length-1)
            {
                index= 0;
            }

        }
        else if(mouseWheel <0)
        {
             index--;

              if((int)index < 0)
            {
                index = (IndexWeapon)(weapons.Length-1);
            }
        }
        weapons[(int)index].SetActive(true);
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

