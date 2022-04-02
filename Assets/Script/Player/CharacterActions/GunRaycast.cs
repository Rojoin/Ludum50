using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class GunRaycast : MonoBehaviour
{
    [SerializeField] Camera fpsCam;
    public int damage = 10;
    public int range = 100;
    public LayerMask hiteableLayer;
    public void Shooting()
    {

        RaycastHit hit;
       if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit,range, hiteableLayer))
        {

            Killable killable = hit.transform.GetComponent<Killable>();

            if (killable != null)
            {
                killable.TakeDamage(damage);
            }
            
        }

    }
}

