using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate = 2f; // Rate at which pipes spawn
    public float spawnHeight = 2f; // Height at which pipes spawn

    private float nextSpawnTime = 0f;

    private void Update()
    {
        // Check if it's time to spawn a new pipe
        if (Time.time >= nextSpawnTime)
        {
            SpawnPipe();
            // Calculate the next spawn time based on the spawn rate
            nextSpawnTime = Time.time + 1f / spawnRate;
        }
    }

    private void SpawnPipe()
    {
        // Randomly determine the height of the gap between pipes
        float randomHeight = Random.Range(-spawnHeight, spawnHeight);
        // Instantiate a new pipe at the spawner's position with the random height
        Instantiate(pipePrefab, transform.position + new Vector3(0, randomHeight, 0), Quaternion.identity);
    }
}
