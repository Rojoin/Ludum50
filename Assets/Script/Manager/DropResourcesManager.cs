using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropResourcesManager : MonoBehaviour
{
    [SerializeField] SwitchingWeapons weapons;
    
    [SerializeField] GameObject ammoOrb, healthOrb;
   
   
        // Start is called before the first frame update

    

    private void OnEnable() 
    {
        BaseEnemy.OnEnemyDead += SpawnItem;
        Cursor.lockState= CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void OnDisable() 
    {
        BaseEnemy.OnEnemyDead -= SpawnItem;
    }
    Transform SpawnItem(Transform tra)
    {
        if(weapons.weapons[0].activeSelf)
        {
               return Instantiate(healthOrb,tra.position, Quaternion.identity,tra).transform;
        }
        else if(weapons.weapons[1].activeSelf)
        {
               return Instantiate(ammoOrb,tra.position, Quaternion.identity,tra).transform;
        }
        return null;
    }
    
}
