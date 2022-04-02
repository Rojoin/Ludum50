using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class GunRaycast : MonoBehaviour
{
   [SerializeField] Camera fpsCam;
   public float damage = 10f;
   public float range = 100f;
    public GameObject aTest;
    public GameObject inpactEffect;
 

   
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void Shooting()
    {

        RaycastHit hit;
       if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Killable killable = hit.transform.GetComponent<Killable>();

            if(killable != null)
            {
                killable.TakeDamage(damage);
            }

            Instantiate(inpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
          // Instantiate(aTest,hit.point,Quaternion.identity,null);
        }
        else{
            Debug.DrawRay(transform.position,Vector3.forward * 5f,Color.green);
        }
        Debug.Log("Click");
    }
    
    // Update is called once per frame
    void Update()
    {
       
    }
}

