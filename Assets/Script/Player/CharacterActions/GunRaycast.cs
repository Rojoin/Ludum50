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
    public delegate void RequestingPistolAttack();
    public static event RequestingPistolAttack OnRequestingPistolAttack;
    public delegate void RequestingNoAmmo();
    public static event RequestingNoAmmo OnRequestingNoAmmo;
    private void Start()
    {
        myAmmo = GetComponent<AmmoSystem>();
    }
    public void Shooting()
    {
        if (myAmmo.GetMagazineBulletsCount() > 0 && !myAmmo.IsReloading)
        {
            OnRequestingPistolAttack?.Invoke();
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
        else
        {
            OnRequestingNoAmmo?.Invoke();
        }

    }
}

