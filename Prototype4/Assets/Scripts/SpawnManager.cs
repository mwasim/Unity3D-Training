using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _powerupPrefab;
    [SerializeField] private int _waveNumber = 1;

    private float _spawnRange = -9.0f;
    private int _enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        //randomize the spawn position
        //var _randomXPos = Random.Range(-_spawnRange, _spawnRange);
        //var _randomZPos = Random.Range(-_spawnRange, _spawnRange);
        //var randomSpawnPos = new Vector3(_randomXPos, 0, _randomZPos);

        SpawnEnemyWave(_waveNumber);
    }

    private void SpawnEnemyWave(int noOfEnemiesToSpawn)
    {
        for (int i = 0; i < noOfEnemiesToSpawn; i++)
        {
            //var randomSpawnPos = GenerateSpawnPosition();

            Instantiate(_enemyPrefab, GenerateSpawnPosition(), _enemyPrefab.transform.rotation);
        }

        //also spawn powerups with each enemy wave
        SpawnPowerups(numberOFPowerupsToSpawn: noOfEnemiesToSpawn == 1 ? 1 : noOfEnemiesToSpawn - 1);
    }

    private void SpawnPowerups(int numberOFPowerupsToSpawn)
    {
        for (int i = 0; i < numberOFPowerupsToSpawn; i++)
        {
            //var randomSpawnPos = GenerateSpawnPosition();

            Instantiate(_powerupPrefab, GenerateSpawnPosition(), _powerupPrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        _enemyCount = FindObjectsOfType<Enemy>().Length;

        if (_enemyCount <= 0)
        {
            _waveNumber++;
            SpawnEnemyWave(_waveNumber);
        }
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
