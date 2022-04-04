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
    public void OnStart(Vector3 hitpoint)
    {
        targetPoint = hitpoint;
        transform.LookAt(-transform.forward + transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {

        }
    }
    private void Update()
    {
        rb.velocity = (transform.position - targetPoint).normalized * speed * Time.deltaTime;
    }

}
