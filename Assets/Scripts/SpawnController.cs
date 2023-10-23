using System.Collections;
using System.Collections.Generic;
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


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SetSpawn", spawnDelay, spawnInt);
        InvokeRepeating("Spawning", startDelay, interval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetSpawn()
    {
        spawnPos = new Vector3(Random.Range(-radius, radius), 2, Random.Range(-radius, radius));
    }

    void Spawning()
    {
        Instantiate(enemy, spawnPos, transform.rotation);
    }
}
