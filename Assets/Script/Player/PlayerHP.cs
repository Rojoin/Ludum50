using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public MusicManager musicTrasition;
    public float currentLifePoints = 100;
    public float maxLifePoints = 100;
    public float decreasePerSecond;
    public bool isDead = false;
    public delegate void RequestingPlayerDamaged();
    public static event RequestingPlayerDamaged OnRequestingPlayerDamaged;
    public delegate void RequestingPlayerHeal();
    public static event RequestingPlayerHeal OnRequestingPlayerHeal;
    public void TakeDamage(int dmg)
    {
        currentLifePoints -= dmg;
        if (currentLifePoints < 1)
        {
            isDead = true;
        }
        else
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
      currentLifePoints -=Time.deltaTime * decreasePerSecond;
    }
}
