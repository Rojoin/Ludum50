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
    public virtual void TakeDamage(int ammount)
    {
        me.OnHurt(ammount);
    }
}