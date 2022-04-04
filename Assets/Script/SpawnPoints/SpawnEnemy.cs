using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public Transform[] spawnPointsEnemy;
    public GameObject[] baseEnemy;
    public float timer = 0.0f;
    public float constantTimer = 10.0f;
    public float random;
    public float maxRandomTimer = 0.0f;
    public Transform player;
    public delegate void RequestingEnemyGiantSpawn();
    public static event RequestingEnemyGiantSpawn onRequestingEnemySpawn;



    void spawner ()
    {
        int i = Random.Range(0, spawnPointsEnemy.Length);
        int j = Random.Range(0, baseEnemy.Length);
        GameObject Aux = Instantiate(baseEnemy[j], spawnPointsEnemy[i].position,transform.rotation,null);
        Aux.GetComponent<BaseEnemy>().SetReference(player);
    }

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("spawner", 1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= (constantTimer + random))
        {
            spawner();
            onRequestingEnemySpawn?.Invoke();
            random = Random.Range (0, maxRandomTimer);
            timer = 0.0f;
        }

    }
}
