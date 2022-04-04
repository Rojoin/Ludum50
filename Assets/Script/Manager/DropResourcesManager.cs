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
    }
    private void OnDisable() 
    {
        BaseEnemy.OnEnemyDead -= SpawnItem;
    }
    void SpawnItem(Vector3 position)
    {
        if(weapons.index == 0)
        {
               Instantiate(healthOrb,position, Quaternion.identity);
        }
        else
        {
               Instantiate(ammoOrb,position, Quaternion.identity);
        }
    }
    
}
