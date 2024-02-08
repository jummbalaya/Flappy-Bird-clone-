using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject pipePrefab;
    // Rate at which pipes spawn
    [SerializeField] float spawnRate = 0.5f;
    // Height at which pipes spawn
    [SerializeField] float spawnHeight = 3f;

    float nextSpawnTime = 0f;

    void Update()
    {
        // Check if it's time to spawn a new pipe
        if (Time.time >= nextSpawnTime)
        {
            SpawnPipe();
            // Calculate the next spawn time based on the spawn rate
            nextSpawnTime = Time.time + 1f / spawnRate;
        }
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
