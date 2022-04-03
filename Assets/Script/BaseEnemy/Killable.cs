using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killable : MonoBehaviour
{
    private BaseEnemy me;
    void Start()
    {
        me = GetComponent<BaseEnemy>();
    }
    public void TakeDamage(int ammount)
    {
        me.OnHurt(ammount);
    }
}