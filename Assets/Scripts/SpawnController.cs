using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public Vector3 spawnPos;
    public GameObject enemy;
    public float radius = 9;

    public float startDelay;
    public float interval;

    public float spawnDelay;
    public float spawnInt;

    public int enemyNum = 1;
    public int currentEnemies;

    public GameObject powerUp;


    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SetSpawn", spawnDelay, spawnInt);
        //InvokeRepeating("Spawning", startDelay, interval);
    }

    // Update is called once per frame
    void Update()
    {
        currentEnemies = FindObjectsByType<EnemyController>(0).Length;
        if(currentEnemies <= 0)
        {
            SpawnEnemies(enemyNum);
        }
        
    }

    void SpawnEnemies(int enemies)
    {
        Vector3 powerSpawn = new Vector3(Random.Range(-radius, radius), 0, Random.Range(-radius, radius));
        Instantiate(powerUp, powerSpawn, transform.rotation);

        for(int i = 0; i < enemies; i++)
        {
            spawnPos = new Vector3(Random.Range(-radius, radius), 2, Random.Range(-radius, radius));
            Instantiate(enemy, spawnPos, transform.rotation);
        }
        enemyNum += 1;
;
    }
}
