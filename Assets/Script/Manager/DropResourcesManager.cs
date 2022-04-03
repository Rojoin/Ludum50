using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropResourcesManager : MonoBehaviour
{
    [SerializeField] SwitchingWeapons weapons;
    
    
        // Start is called before the first frame update
    void Start()
    {
        
    }


    public void DropItem()
    {
        if(weapons.weaponIndex == 0)
        {
               dropHealth = true;
        }
        else
        {

        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
