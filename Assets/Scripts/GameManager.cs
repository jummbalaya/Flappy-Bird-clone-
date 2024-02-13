using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject pipePrefab;
    [SerializeField] GameObject buffPrefab;
    // Rate at which pipes spawn
    [SerializeField] float spawnRate = 0.5f;
    [SerializeField] float buffSpawnRate = 0.4f;
    // Height at which pipes spawn
    [SerializeField] float spawnHeight = 3f;

    float nextSpawnTime = 0f;
    private float nextBuffSpawnTime;

    void Update()
    {
        // Check if it's time to spawn a new pipe
        if (Time.time >= nextSpawnTime)
        {
            SpawnPipe();
            // Calculate the next spawn time based on the spawn rate
            nextSpawnTime = Time.time + 1f / spawnRate;
        }
        if (Time.time >= nextBuffSpawnTime)
        {
            SpawnBuff();
            // Calculate the next spawn time based on the spawn rate
            nextBuffSpawnTime = Time.time + 1f / buffSpawnRate;
        }
    }

    private void SpawnBuff()
    {
        float randomHeight = Random.Range(-spawnHeight, spawnHeight);
        Instantiate(buffPrefab, transform.position + new Vector3(0, randomHeight, 0), Quaternion.identity);
    }

    void SpawnPipe()
    {
        // Randomly determine the height of the gap between pipes
        float randomHeight = Random.Range(-spawnHeight, spawnHeight);
        // Instantiate a new pipe at the spawner's position with the random height
        Instantiate(pipePrefab, transform.position + new Vector3(0, randomHeight, 0), Quaternion.identity);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
