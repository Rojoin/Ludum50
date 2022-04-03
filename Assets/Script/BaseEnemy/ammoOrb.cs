using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoOrb : MonoBehaviour
{

    public int ammo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Ayuda ammo");
            other.GetComponent<AmmoSystem>().AddReserve(ammo);
            Destroy(gameObject);

        }
    }

}
