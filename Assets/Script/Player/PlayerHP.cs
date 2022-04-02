using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int lifePoints = 100;
    public bool isDead = false;
    public void TakeDamage(int dmg)
    {
        lifePoints -= dmg;
        if (lifePoints < 1) isDead = true;
    }
}
