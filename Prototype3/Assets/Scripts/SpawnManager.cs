using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _obstaclePrefabList;
    [SerializeField] private Vector3 _spawnPos = new Vector3(25, 0, 0);

    private PlayerController _palyerController;

    // Start is called before the first frame update
    void Start()
    {
        _palyerController = FindObjectOfType<PlayerController>();

        InvokeRepeating(nameof(SpawnObstacle), 1f, 2.5f);
    }

    private void SpawnObstacle()
    {
        bool isGameOver = _palyerController != null ? _palyerController.IsGameOver : false;

        if (isGameOver == false)
        {
            var randomIndex = Random.Range(0, _obstaclePrefabList.Count);

            Instantiate(_obstaclePrefabList[randomIndex], _spawnPos, _obstaclePrefabList[randomIndex].transform.rotation);
        }
    }
}
