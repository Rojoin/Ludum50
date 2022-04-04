using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthOrb : MonoBehaviour
{

    
    public int healthPoints = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Ayuda health");
            other.GetComponent<PlayerHP>().ReceiveHealth(healthPoints);
            Destroy(gameObject);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
