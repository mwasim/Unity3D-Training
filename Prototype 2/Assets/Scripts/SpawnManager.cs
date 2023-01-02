using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _animalPrefabs;
    [SerializeField] private Vector3[] _spanwnPositions;

    // Start is called before the first frame update
    void Start()
    {
        //Invokes the method methodName in time seconds, then repeatedly every repeatRate seconds.
        InvokeRepeating(nameof(SpawnRandomAnimals), 1.5f, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    var randomAnimalIndex = Random.Range(0, _animalPrefabs.Length);
        //    var randomSpawnPositionIndex = Random.Range(0, _spanwnPositions.Length);

        //    Instantiate(_animalPrefabs[randomAnimalIndex], _spanwnPositions[randomSpawnPositionIndex], _animalPrefabs[randomAnimalIndex].transform.rotation);
        //}
    }

    private void SpawnRandomAnimals()
    {
        var randomAnimalIndex = Random.Range(0, _animalPrefabs.Length);
        var randomSpawnPositionIndex = Random.Range(0, _spanwnPositions.Length);

        Instantiate(_animalPrefabs[randomAnimalIndex], _spanwnPositions[randomSpawnPositionIndex], _animalPrefabs[randomAnimalIndex].transform.rotation);
    }
}
