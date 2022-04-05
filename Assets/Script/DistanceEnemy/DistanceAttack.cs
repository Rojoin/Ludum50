using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceAttack : BaseAttack
{
    public BulletEnemy bulletPrefab;
    public Transform spawnBulletPosition;

    [SerializeField] int bulletsObjectPooling;

    List<BulletEnemy> bullets;

    int index;
    protected override void Start() {
        base.Start();

        target = FindObjectOfType<StarterAssets.FirstPersonController>().gameObject;

        bullets = new List<BulletEnemy>();

        for (int i = 0; i < bulletsObjectPooling; i++) {
            bullets.Add(Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity));
            bullets[i].gameObject.SetActive(false);
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
        Debug.Log("PUTA");
        RaycastHit hit;
        if (Physics.Raycast(spawnBulletPosition.position, spawnBulletPosition.position + spawnBulletPosition.forward, out hit, 1000)) {
            if (hit.transform.CompareTag("Player")) {
                Debug.Log("wachin");
                bullets[index].gameObject.SetActive(true);
                bullets[index].SetProjectile((target.transform.position - spawnBulletPosition.position).normalized);

                index++;
                if (index >= bullets.Count)
                    index = 0;
            }
            Debug.Log(hit.transform.name);
        }
    }
    private void Update()
    {
        //Debug.DrawLine(spawnBulletPosition.position, ( spawnBulletPosition.position - (target.transform.position + rayOffset) ).normalized * 10, Color.red);
        Debug.DrawLine(transform.position,transform.position + transform.forward * 10,Color.red);
    }
}
