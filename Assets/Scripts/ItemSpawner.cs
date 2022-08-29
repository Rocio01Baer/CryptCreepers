using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField]GameObject checkpointPrefab;
    [SerializeField] int checkpointSpawnDelay = 10;
    [SerializeField] float spawnRadius = 10f;
    [SerializeField] GameObject[] powerUpPrefab;
    [SerializeField] int powerUpSpawnDelay = 12;
    void Start()
    {
        StartCoroutine(SpawnCheckpointRoutine());
        StartCoroutine(SpawnPowerUpRoutine());
    }
    IEnumerator SpawnCheckpointRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(checkpointSpawnDelay);
            Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;
            Instantiate(checkpointPrefab, randomPosition, Quaternion.identity);
        }
    }

    IEnumerator SpawnPowerUpRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(powerUpSpawnDelay);
            Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;
            int random = Random.Range(0, powerUpPrefab.Length);
            Instantiate(powerUpPrefab[random], randomPosition, Quaternion.identity);
        }
    }
}
