using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace customDistanceAttack
{

public class DistanceAttack : BaseAttack
{
   public  GameObject direction; 
    public GameObject[] bullet;
    public GameObject prefabBullet;
    public Transform firePoint;
    public Vector3 destination;

    public GameObject a;
    int balaIndex = 0;
    
    

    // Start is called before the first frame update
    void Start()
    {
        balaIndex = 0;
        canAttack = true;
        endAttack = false;
        for (int i = 0; i< bullet.Length; i++)
        {
          
          bullet[i] = Instantiate(prefabBullet,transform.position,Quaternion.identity,transform);

        }
    }

    void ShootProjectile()
    {
        Debug.Log("Shoot Projectile");
        balaIndex++;
        Ray ray = new Ray(transform.position,Vector3.forward);
        RaycastHit hit;
        
        Debug.Log("Atacando");
        if(Physics.Raycast(ray,out hit))
        {
            destination = hit.point;
            Instantiate(a,hit.point,Quaternion.identity);
        }
        else
        {

            destination = ray.GetPoint(1000);
            Instantiate(a,destination,Quaternion.identity);
        }
        if(balaIndex >bullet.Length-1)
        {
            balaIndex = 0;
        }
       bullet[balaIndex].SetActive(true);


        
    }

    public override IEnumerator Attacking()
    {Debug.Log("Coroutine");
        canAttack = false;
        endAttack = false;
        yield return new WaitForSeconds(timeWaitingToTryHit);
        ShootProjectile();
         endAttack = true;
        yield return new WaitForSeconds(attackCooldown);
         canAttack = true;
    }
    void InstatiateProjectile()
    {
        
    }
}

}