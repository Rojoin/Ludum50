using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class countBullets1 : MonoBehaviour
{
    public TMP_Text contBullets;
    //int magazine = 30;
    public TMP_Text maxBullet;
    //int reserveBullets = 50;
    //int diffBulletsReload;
    //int maxBullestInMagazine = 30;
    //int diffBullets;
    //public float fireRate = 0.0f;

    //public float reloadTime = 1.5f;
    //private float lastTimeShoot = Mathf.NegativeInfinity;

    //private bool reload;

    //private bool TryShoot()
    //{
    //    if (reload == false)
    //    {
    //        if (lastTimeShoot + fireRate < Time.time)
    //        {
    //            if (magazine >= 1)
    //            {
    //                magazine--;
    //                lastTimeShoot = Time.time;
    //                return true;
    //            }
    //        }
    //    } 
    //    return false;
    //}
    //IEnumerator Reload()
    //{
    //    if (reserveBullets > 0)
    //    {
    //        reload = true;


    //        yield return new WaitForSeconds(reloadTime);

    //        diffBullets = maxBullestInMagazine - magazine;
    //        reserveBullets = reserveBullets - diffBullets;

    //        if (reserveBullets < 0)
    //        {
    //            //diffBullets -= reserveBullets;
    //            magazine = magazine + reserveBullets;
    //            reserveBullets = 0;
    //        }
    //        else
    //        {
    //            magazine = magazine + diffBullets;
    //        }
    //    }

    //    //diffBullets = 0;
    //    reload = false;
    //}

    public int magazineSize = 200;
    public int ammo = 200;
    public int ammo_Hold = 600;
    public bool reload = false;
    public bool readyToShoot;

    // Update is called once per frame
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
            reload = true;
        }
    }

    void Reload()
    {

        if (ammo == 0)
        {
            if (ammo_Hold < magazineSize)
            {
                ammo = ammo_Hold;
                ammo_Hold = 0;
            }
            else
            {
                ammo = magazineSize;
                ammo_Hold = ammo_Hold - magazineSize;
            }
        }

        else if (reload == true && ammo_Hold >= 0)
        {
            if (ammo_Hold >= (magazineSize - ammo)) //Check if you have enough ammo to do a full reload.
            {
                ammo = magazineSize;
                ammo_Hold = ammo_Hold - (magazineSize - ammo);
            }
            else
            {
                ammo = ammo + ammo_Hold;
                ammo_Hold = 0;
            }

            reload = false;
        }


        //// Update is called once per frame
        //void Update()
        //{


        //    if(Input.GetMouseButtonDown(0))
        //    {
        //        TryShoot();
        //    }

        //    if(magazine < 0)
        //    {
        //        magazine = 0;
        //    }

        //    if(Input.GetKey(KeyCode.R))
        //    {
        //        StartCoroutine(Reload());
        //    }

        //    contBullets.text = magazine.ToString();
        //    maxBullet.text = reserveBullets.ToString();
        //}
    }
}




