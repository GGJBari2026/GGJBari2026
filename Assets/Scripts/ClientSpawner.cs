using System.Collections;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using Unity.VisualScripting;
using UnityEngine;

public class ClientSpawner : MonoBehaviour
{
    public Sprite[] spawnSprites;
    public int[] spawnChances;
    
    [SerializeField] private GameObject clientPrefab;
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
        foreach (var chance in spawnChances)
        {
            totalChance += chance;
        }
        var randomValue = Random.Range(0, totalChance);
        var cumulativeChance = 0;
        Sprite selectedSprite = null;
        for (var i = 0; i < spawnSprites.Length; i++)
        {
            cumulativeChance += spawnChances[i];
            if (randomValue < cumulativeChance)
            {
                selectedSprite = spawnSprites[i];
                break;
            }
        }

        var newClient = Instantiate(clientPrefab, transform.position, Quaternion.identity);
        newClient.GetComponent<SpriteRenderer>().sprite = selectedSprite;
        var newClientManager = newClient.GetComponent<ClientManager>();
        newClientManager.OnEnd += SpawnClientSync;
    }
    
    private void SpawnClientSync()
    {
        StartCoroutine(SpawnClient());
    }
}
