using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceAttack : BaseAttack
{
    public GameObject bulletPrefab;
    public GameObject[] bullets;
    BulletEnemy[] shootScript;
    int index;
    protected override void Start()
    {
        base.Start();
        for(int i = 0; i < bullets.Length;i++)
        {
            bullets[i] = Instantiate(bulletPrefab,transform);
        }
        shootScript = new BulletEnemy[bullets.Length];

        for (int i = 0; i < bullets.Length; i++)
        {
            shootScript[i] =bullets[i].GetComponent<BulletEnemy>();
        }
    }
    public override IEnumerator Attacking()
    {

        endAttack = false;
        canAttack = false;
        yield return new WaitForSeconds(timeWaitingToTryHit);
        yield return new WaitForSeconds(timeTryingHit);
        ShootBullet();
        yield return new WaitForSeconds(timeRestToEnd);
        endAttack = true;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
    void ShootBullet()
    {
        shootScript[index].OnStart();
        bullets[index].SetActive(true);
        index++;
        if (index >= bullets.Length) index = 0;
    }
}
