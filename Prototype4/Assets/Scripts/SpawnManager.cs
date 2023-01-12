using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;

    private float _spawnRange = -9.0f;

    // Start is called before the first frame update
    void Start()
    {
        //randomize the spawn position
        //var _randomXPos = Random.Range(-_spawnRange, _spawnRange);
        //var _randomZPos = Random.Range(-_spawnRange, _spawnRange);
        //var randomSpawnPos = new Vector3(_randomXPos, 0, _randomZPos);

        var randomSpawnPos = GenerateSpawnPosition();

        Instantiate(_enemyPrefab, randomSpawnPos, _enemyPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private Vector3 GenerateSpawnPosition()
    {
        //randomize the spawn position
        var _randomXPos = Random.Range(-_spawnRange, _spawnRange);
        var _randomZPos = Random.Range(-_spawnRange, _spawnRange);
        var randomSpawnPos = new Vector3(_randomXPos, 0, _randomZPos);

        return randomSpawnPos;
    }
}
