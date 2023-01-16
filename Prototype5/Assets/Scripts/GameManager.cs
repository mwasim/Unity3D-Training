using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _targets;
    [SerializeField] private float _spawnRate = 1.0f;
    [SerializeField] private TextMeshProUGUI _scoreText;
    //[SerializeField] private TextMeshProUGUI _gameOverText;
    [SerializeField] private GameObject _gameOverMenu;
    [SerializeField] private GameObject _startMenu;
    [SerializeField] private Button _buttonRestart;

    private int _score;
    private bool _isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        _buttonRestart.onClick.AddListener(RestartGame);
    }

    private void OnDisable()
    {
        _buttonRestart.onClick.RemoveListener(RestartGame);
    }

    private IEnumerator SpawnTarget()
    {
        while (!_isGameOver) //as long as game is not  over, spawn objects
        {
            yield return new WaitForSeconds(_spawnRate);

            var randomIndex =UnityEngine.Random.Range(0, _targets.Count);
            Instantiate(_targets[randomIndex]);
        }
    }

    public void UpdateScore(int scoreToAd)
    {
        _score += scoreToAd;

        //Debug.Log($"Score {scoreToAd} added: {_score}");

        ScoreText = _score;
    }

    public void GameOver()
    {
        _isGameOver = true;
        _gameOverMenu.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartGame(GameDifficulty difficulty)
    {
        _startMenu.gameObject.SetActive(false);

        _isGameOver = false;
        _score = 0;
        ScoreText = _score;

        _spawnRate /= (int)difficulty;

        StartCoroutine(SpawnTarget());
    }

    public bool IsGameOver => _isGameOver;
    private int ScoreText { set { _scoreText.text = $"Score: {value}"; } }
}
