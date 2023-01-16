using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameDifficulty
{
    EASY = 1,
    MEDIUM = 2,
    HARD = 3
}

public class DifficultyButton : MonoBehaviour
{
    [Header("Difficulty")]
    [SerializeField] GameDifficulty _difficulty;

    private Button _button;
    private GameManager _gameManager;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    // Start is called before the first frame update
    void Start()
    {       
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(SetDifficulty);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(SetDifficulty);
    }

    private void SetDifficulty()
    {
        _gameManager.StartGame(_difficulty);
    }
}
