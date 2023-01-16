using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _targets;
    [SerializeField] private float _spawnRate = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
    }

    private IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnRate);

            var randomIndex = Random.Range(0, _targets.Count);
            Instantiate(_targets[randomIndex]);
        }
    }
}
