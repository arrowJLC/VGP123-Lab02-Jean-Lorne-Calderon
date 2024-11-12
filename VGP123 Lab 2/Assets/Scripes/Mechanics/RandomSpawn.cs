using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    public List<Transform> spawnPoints;
    public List<GameObject> collectiblePrefabs;

    void Start()
    {
        SpawnCollectibles();
    }

    void SpawnCollectibles()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            // Randomly select a collectible prefab from the list
            GameObject collectible = collectiblePrefabs[Random.Range(0, collectiblePrefabs.Count)];
            // Instantiate the collectible at the spawn point location
            Instantiate(collectible, spawnPoint.position, Quaternion.identity);
        }
    }
}