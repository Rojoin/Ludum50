using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killable : MonoBehaviour
{
     public float Health =20f;

     public void TakeDamage(float ammount)
     {
         Health-= ammount;
         if(Health <= 0f)
         {
             Die();
         }
     }

      void Die() 
      {   
         Destroy(gameObject);
      }

  
}