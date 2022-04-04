using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public float currentLifePoints = 100;
    public float maxLifePoints = 100;
    public float decreasePerSecond;
    public bool isDead = false;
    public delegate void RequestingPlayerDamaged();
    public static event RequestingPlayerDamaged OnRequestingPlayerDamaged;
    public delegate void RequestingPlayerHeal();
    public static event RequestingPlayerHeal OnRequestingPlayerHeal;
    public delegate void RequestingPlayerDeath();
    public static event RequestingPlayerDeath OnRequestingPlayerDeath;
    public delegate void RequestingLowHP();
    public static event RequestingLowHP OnRequestingLowHP;
    public void TakeDamage(float dmg)
    {
        currentLifePoints -= dmg;
        if (currentLifePoints <=0)
        {
            isDead = true;
            OnRequestingPlayerDeath?.Invoke();
        }
        else
        {
            OnRequestingPlayerDamaged?.Invoke();
        }
    }
    public void TakeDamage(float dmg,bool isBackgroundDamage)
    {
        currentLifePoints -= dmg;
        if (currentLifePoints <= 0)
        {
            isDead = true;
            OnRequestingPlayerDeath?.Invoke();
        }
        else if (!isBackgroundDamage)
        {
            OnRequestingPlayerDamaged?.Invoke();
        }
    }

    public float GetCurrentLifePoints()
    {
        return currentLifePoints;
    }
    public void ReceiveHealth(int health)
    {
        currentLifePoints+=health;
        currentLifePoints=(currentLifePoints >maxLifePoints) ? maxLifePoints : currentLifePoints;
        OnRequestingPlayerHeal?.Invoke();

    }
    void Update()
    {
      TakeDamage(Time.deltaTime * decreasePerSecond,true);
    }
}
