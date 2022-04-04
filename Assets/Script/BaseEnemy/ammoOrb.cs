using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoOrb : MonoBehaviour
{
    public int ammo;
    public delegate void RequestingPickUpAmmo();
    public static event RequestingPickUpAmmo OnRequestingPickUpAmmo;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Ayuda ammo");
            other.GetComponent<AmmoSystem>().AddReserve(ammo);
            Destroy(gameObject);
            OnRequestingPickUpAmmo?.Invoke();
        }
    }

}
