using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCubeDamager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHP>().TakeDamage(5.0f);
        }
    }
}
