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
    public AmmoSystem myAmmo;
    private void Start()
    {
        myAmmo = GetComponent<AmmoSystem>();
    }
    public void Shooting()
    {
        if (myAmmo.GetMagazineBulletsCount() > 0 && !myAmmo.IsReloading)
        {
            myAmmo.RemoveOneBullet();
            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range, hiteableLayer))
            {

                Killable killable = hit.transform.GetComponent<Killable>();

                if (killable != null)
                {
                    killable.TakeDamage(damage);
                }

            }
        }

    }
}

