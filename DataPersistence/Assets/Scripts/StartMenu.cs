using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _bestScoreText;
    [SerializeField] private TMP_InputField _nameText;

    [SerializeField] private Button _buttonStart;
    [SerializeField] private Button _buttonQuit;

    // Start is called before the first frame update
    void Start()
    {
        _nameText.text = DataManager.Instance.PlayerName;
        var bestScore = DataManager.Instance.BestScore;

        if (bestScore > 0)
        {
            _bestScoreText.text = $"Best Score: {bestScore}";
        }
    }

    private void OnEnable()
    {
        _buttonStart.onClick.AddListener(StartGame);
        _buttonQuit.onClick.AddListener(QuitGame);
    }

    private void OnDisable()
    {
        _buttonStart.onClick.RemoveListener(StartGame);
        _buttonQuit.onClick.RemoveListener(QuitGame);
    }

    private void StartGame()
    {
        var savedPlayerName = DataManager.Instance.PlayerName;
        var enteredPlayerName = _nameText.text;

        if(string.Compare(savedPlayerName, enteredPlayerName, System.StringComparison.OrdinalIgnoreCase) != 0)
        {
            DataManager.Instance.BestScore = 0;
            DataManager.Instance.PlayerName = enteredPlayerName;
        }

        SceneManager.LoadScene("main");
    }

    private void QuitGame()
    {
        Application.Quit();
        Debug.Log("Application is Quit");
        //#if (UNITY_EDITOR)
        //    Application.Quit();
        //#elif
        //Application.Quit();
        //#endif
    }
}
