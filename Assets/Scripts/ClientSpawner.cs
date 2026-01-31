using System.Collections;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using Unity.VisualScripting;
using UnityEngine;

public class ClientSpawner : MonoBehaviour
{
    [SerializedDictionary("Client", "Chance")]
    public SerializedDictionary<GameObject, int> spawnPrefabsAndChance;

    [SerializeField] private float spawnDelay;
    
    private void Start()
    {
        SpawnClientSync();
    }
    
    private IEnumerator SpawnClient()
    {
        yield return new WaitForSeconds(spawnDelay);
        if (!GameManager.gameManager.gameStarted) yield break;
        var totalChance = 0;
        foreach (var chance in spawnPrefabsAndChance.Values)
        {
            totalChance += chance;
        }
        var randomValue = Random.Range(0, totalChance);
        var cumulativeChance = 0;
        GameObject selectedPrefab = null;
        foreach (var kvp in spawnPrefabsAndChance)
        {
            cumulativeChance += kvp.Value;
            if (randomValue < cumulativeChance)
            {
                selectedPrefab = kvp.Key;
                break;
            }
        }
        if (selectedPrefab == null) yield break;
        var newClient = Instantiate(selectedPrefab, transform.position, Quaternion.identity);
        var newClientManager = newClient.GetComponent<ClientManager>();
        newClientManager.OnEnd += SpawnClientSync;
    }
    
    private void SpawnClientSync()
    {
        StartCoroutine(SpawnClient());
    }
}
