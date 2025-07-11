using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [Header("Spawner Settings")]
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public float spawnDelay = 3f;
    public int maxEnemies = 10;

    private int currentEnemyCount = 0;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (currentEnemyCount < maxEnemies)
        {
            SpawnEnemy();
            currentEnemyCount++;

            yield return new WaitForSeconds(spawnDelay);
        }

        Debug.Log("Max enemies reached, spawner stopped.");
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
