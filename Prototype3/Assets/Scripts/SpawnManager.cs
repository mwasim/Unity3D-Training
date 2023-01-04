using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _obstaclePrefab;
    [SerializeField] private Vector3 _spawnPos = new Vector3(25, 0, 0);

    private PlayerController _palyerController;

    // Start is called before the first frame update
    void Start()
    {
        _palyerController = FindObjectOfType<PlayerController>();

        InvokeRepeating(nameof(SpawnObstacle), 1f, 2f);
    }

    private void SpawnObstacle()
    {
        bool isGameOver = _palyerController != null ? _palyerController.IsGameOver : false;

        if (isGameOver == false)
        {
            Instantiate(_obstaclePrefab, _spawnPos, _obstaclePrefab.transform.rotation);
        }
    }
}
