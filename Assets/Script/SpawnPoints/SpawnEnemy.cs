using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public Transform[] spawnPointsEnemy;
    public GameObject BaseEnemy;

    void spawner ()
    {
        int i = Random.Range(0, 3);
        Instantiate(BaseEnemy, spawnPointsEnemy[i].position,transform.rotation);
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawner", 5, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
