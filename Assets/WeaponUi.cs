using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUi : MonoBehaviour
{
    public GameObject gun;
    public GameObject katana;
  private void OnEnable() 
  {
      SwitchingWeapons.OnActualWeapon += ChangeHud;
  }


  private void OnDisable() 
  {
      SwitchingWeapons.OnActualWeapon -= ChangeHud;
  }

  public void ChangeHud(SwitchingWeapons.IndexWeapon indexWeapon)
  {
      gun.SetActive(false);
      katana.SetActive(false);
      if(SwitchingWeapons.IndexWeapon.gun == indexWeapon)
      {
          gun.SetActive(true);
      }
      if(SwitchingWeapons.IndexWeapon.katana == indexWeapon)
      {
          katana.SetActive(true);
      }
  }
}
