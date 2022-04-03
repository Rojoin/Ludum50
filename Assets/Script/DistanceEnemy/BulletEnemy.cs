using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public Vector3 targetPoint = Vector3.zero;
    Rigidbody rb;
    public float speed;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }
    public void OnStart()
    {
        transform.LookAt(targetPoint);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {

        }
    }
    private void Update()
    {
        rb.velocity = transform.forward * speed * Time.deltaTime;
    }

}
