using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _targets;
    [SerializeField] private float _spawnRate = 1.0f;
    [SerializeField] private TextMeshProUGUI _scoreText;

    private int _score;

    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
        ScoreText = _score;

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

    public void UpdateScore(int scoreToAd)
    {
        _score += scoreToAd;

        Debug.Log($"Score {scoreToAd} added: {_score}");

        ScoreText = _score;
    }

    private int ScoreText { set { _scoreText.text = $"Score: {value}"; } }
}
