using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    Rigidbody rb;
    Collider col;

    bool collided = false;
    Vector3 direccionoObjetiva;
    [SerializeField] float projectileSpeed = 10;
    [SerializeField]float velocity = 10; 
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
     transform.LookAt(GetComponentInParent<customDistanceAttack.DistanceAttack>().destination);
     transform.parent=null;

    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag !="Player" && !collided)
        {
            collided = true;
            gameObject.SetActive(false);
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        rb.velocity = -transform.forward * velocity * Time.deltaTime;
        
    }
}
