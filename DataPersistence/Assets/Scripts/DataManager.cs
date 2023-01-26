using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static DataManager _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private const string PLAYER_NAME_KEY = "PlayerNameKey";
    public string PlayerName
    {
        get
        {
            var palyerName = string.Empty;
            if (PlayerPrefs.HasKey(PLAYER_NAME_KEY))
                palyerName = PlayerPrefs.GetString(PLAYER_NAME_KEY);

            return palyerName;
        }
        set
        {
            PlayerPrefs.SetString(PLAYER_NAME_KEY, value);
        }
    }

    private const string BEST_SCORE_KEY = "BestScoreKey";
    public int BestScore
    {
        get
        {
            var bestScore = 0;
            if (PlayerPrefs.HasKey(BEST_SCORE_KEY))
                bestScore = PlayerPrefs.GetInt(BEST_SCORE_KEY);

            return bestScore;
        }
        set
        {
            PlayerPrefs.SetInt(BEST_SCORE_KEY, value);
        }
    }

    public static DataManager Instance => _instance;
}
