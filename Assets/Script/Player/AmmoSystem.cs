using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AmmoSystem : MonoBehaviour
{
    public int magazine;
    public int reserve;
    public int maxMagazine;
    public bool reloading;
    public float timeToReload;
    public float timeToEndAnim;
    public delegate void MagazineChange(int newValue);
    public static event MagazineChange OnMagazineChange;
    public delegate void ReserveChange(int newValue);
    public static event ReserveChange OnReserveChange;
    

    public bool IsReloading { get { return reloading; } }
    void Start()
    {
        reloading = false;    
    }
    void OnRecharge()
    {
        /*if (!reloading)
        {
            StartCoroutine(Reloading());
        }*/
    }
    public void RemoveOneBullet()
    {
        if (magazine > 0)
        {
            magazine--;
            OnMagazineChange?.Invoke(magazine);
        }
    }
    public void AddReserve(int extra)
    {
        if(magazine <10)
        {
            magazine += extra;
            if(magazine >10)
            {
                magazine =10;
            }
            OnMagazineChange?.Invoke(magazine);
        }

        
    }
    public int GetMagazineBulletsCount()
    {
        return magazine;
    }
    /*IEnumerator Reloading()
    {
        reloading = true;
        yield return new WaitForSeconds(timeToReload);
        if (reloading && maxMagazine > magazine)
        {
            int dif = maxMagazine - magazine;
            if (dif <= reserve)
            {
                reserve -= dif;
                magazine += dif;
            }
            else
            {
                magazine += reserve;
                reserve = 0;
            }
            OnMagazineChange?.Invoke(magazine);
            OnReserveChange?.Invoke(reserve);
        }
        yield return new WaitForSeconds(timeToEndAnim);
        reloading = false;
    }*/
}
