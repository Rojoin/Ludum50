using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class SwitchingWeapons : MonoBehaviour
{
    public InputAction scroll;
    public GameObject weaponHolder;
    float mouseWheel =0f; 
    private bool isNotScrolling;
    public GameObject[] weapons;

    public delegate void ActualWeapon(IndexWeapon indexWeapon);
    public static event ActualWeapon OnActualWeapon;
   public GameObject gun;
   public GameObject katana;
    
    public enum IndexWeapon{gun,katana};
    public IndexWeapon index;
    
    // Start is called before the first frame update
    void Start()
    {
        isNotScrolling = true;
        index = IndexWeapon.gun;
    }
    void OnScroll()
    {
        
       SelectWeapon();
        

         
    }
    // Update is called once per frame
    public void SelectWeapon()
    {
       mouseWheel =Mouse.current.scroll.y.ReadValue();
   
/*
      if(mouseWheel !=0)
      {
        weapons[(int)index].SetActive(false);

        if(mouseWheel >0)
        {
            index++;
            Debug.Log("Anda");
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
      }*/
    
       if(mouseWheel != 0 && isNotScrolling)
       {
        if(mouseWheel >0)
        {
          if(gun.activeSelf == true)
          {
              Debug.Log("Anda");
              katana.SetActive(true);
              gun.SetActive(false);
                OnActualWeapon?.Invoke(IndexWeapon.katana);      
          }
          else if(katana.activeSelf == true)
          {
              gun.SetActive(true);
              katana.SetActive(false);
                OnActualWeapon?.Invoke(IndexWeapon.gun);      
          }
        }
        else if(mouseWheel <0)
        {
            if(gun.activeSelf == true)
          {
              Debug.Log("Anda");
              katana.SetActive(true);
              gun.SetActive(false);
              OnActualWeapon?.Invoke(IndexWeapon.katana);          
          }
          else if(katana.activeSelf == true)
          {
              gun.SetActive(true);
              katana.SetActive(false);
                OnActualWeapon?.Invoke(IndexWeapon.gun);    
          } 

        }
        isNotScrolling = false;
        
            
       }
      else if(mouseWheel == 0 && !isNotScrolling)
      {
          isNotScrolling = true;
      }
    
     

        
        
    }
}

 
