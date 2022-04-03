using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{

    public float currentLifePoints = 100;
    public float maxLifePoints = 100;
    public float decreasePerSecond;
    public bool isDead = false;
    public void TakeDamage(int dmg)
    {
        currentLifePoints -= dmg;
        if (currentLifePoints < 1) isDead = true;
    }

    public void ReceiveHealth(int health)
    {
        currentLifePoints+=health;
        currentLifePoints=(currentLifePoints >maxLifePoints) ? maxLifePoints : currentLifePoints;

    }
    void Update()
    {
      currentLifePoints -=Time.deltaTime * decreasePerSecond;
    }
}
