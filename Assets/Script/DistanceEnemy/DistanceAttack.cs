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
        RaycastHit hit;
        if (Physics.Raycast(transform.position, (target.transform.position - transform.position).normalized, out hit, 1000))
        {

        }

        shootScript[index].OnStart(hit.point);
        bullets[index].SetActive(true);
        index++;
        if (index >= bullets.Length) index = 0;
    }
    private void Update()
    {
        Debug.DrawLine(transform.position,transform.up * 10,Color.red);
    }
}
