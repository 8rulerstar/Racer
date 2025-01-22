using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelSpawner : MonoBehaviour
{
    public GameObject Fuel;
    public Transform[] spawnPoints = new Transform[5];

    private float minSpawnTime = 2f;
    private float maxSpawnTime = 3f;
    private float SpawnTimer = 0f;
    private float timer = 0f;
    
    void Update()
    {
        if (!BackgroundScroll.isGameStarted)
            return;
        SpawnTimer=Random.Range(minSpawnTime,maxSpawnTime);
        
        timer+=Time.deltaTime;
        if (timer >= SpawnTimer)
        {
            Instantiate(Fuel, spawnPoints[Random.Range(0,5)].position, Quaternion.identity);
            timer = 0f;
        }
    }
}
