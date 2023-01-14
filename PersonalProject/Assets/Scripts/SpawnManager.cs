using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemyPrefabs;
    [SerializeField] private GameObject _powerUpPrefab;

    private float _zEnemySpawnPos = 12.0f;
    private float _zPowerupSpawnPos = 2.5f;

    private float _xSpawnPosRange = 8.0f;
    private float _ySpawnPos = 0.75f;

    private float _startDelay = 1.0f,  _enemySpawnRepeateDelay = 1.0f, _powerUpSpawnRepeatDelay  = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), _startDelay, _enemySpawnRepeateDelay);
        InvokeRepeating(nameof(SpawnPowerup), _startDelay, _powerUpSpawnRepeatDelay);
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

    private void SpawnEnemy()
    {
        var randomIndex = Random.Range(0, _enemyPrefabs.Length);

        Instantiate(_enemyPrefabs[randomIndex], RandomEnemySpawnPos, _enemyPrefabs[randomIndex].transform.rotation);
    }

    private void SpawnPowerup()
    {
        Instantiate(_powerUpPrefab, RandomPowerupSpawnPos, _powerUpPrefab.transform.rotation);
    }
    
    private Vector3 RandomEnemySpawnPos => new Vector3(RandomXPos, _ySpawnPos, _zEnemySpawnPos);
    private Vector3 RandomPowerupSpawnPos => new Vector3(RandomXPos, _ySpawnPos, _zPowerupSpawnPos);

    private float RandomXPos => Random.Range(-_xSpawnPosRange, _xSpawnPosRange);
}
