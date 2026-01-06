using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject _itemPrefab; 
    [SerializeField] private Transform[] _spawnPoints; 

    private void OnEnable()
    {
        CollectibleItem.OnCollected += SpawnRandomItem;
    }

    private void OnDisable()
    {
        CollectibleItem.OnCollected -= SpawnRandomItem;
    }

    private void Start()
    {
        SpawnRandomItem();
    }

    private void SpawnRandomItem()
    {
        int randomIndex = Random.Range(0, _spawnPoints.Length);
        Transform targetPoint = _spawnPoints[randomIndex];

        Instantiate(_itemPrefab, targetPoint.position, targetPoint.rotation);
    }
}
