using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{    
    //тут начинается синглтон + новый текст
    public static MainManager Instance;

    public string playerInputText;

    private const string PLAYER_TEXT_KEY = "PLAYER_INPUT_TEXT";


    // передача очков и имени лучшего игрока в MainManager
    public int bestScore;
    public string bestPlayerName;

    private const string BEST_SCORE_KEY = "BEST_SCORE";
    private const string BEST_NAME_KEY = "BEST_NAME";

    private void Awake()
    {
        // Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadPlayerText();

        LoadBestScore();

    }
 


    // методы для обработки текста с именем игрока
    public void SetPlayerText(string text)
    {
        playerInputText = text;
        PlayerPrefs.SetString(PLAYER_TEXT_KEY, text);
        PlayerPrefs.Save();
    }

    public string GetPlayerText()
    {
        return playerInputText;
    }

    private void LoadPlayerText()
    {
        if (PlayerPrefs.HasKey(PLAYER_TEXT_KEY))
        {
            playerInputText = PlayerPrefs.GetString(PLAYER_TEXT_KEY);
        }
        else
        {
            playerInputText = "";
        }
    }

    private void LoadBestScore()
    {
        bestScore = PlayerPrefs.GetInt(BEST_SCORE_KEY, 0);

        if (PlayerPrefs.HasKey(BEST_NAME_KEY))
            bestPlayerName = PlayerPrefs.GetString(BEST_NAME_KEY);
        else
            bestPlayerName = "Player";
    }


    public bool TrySetBestScore(int score)
    {
        if (score <= bestScore)
            return false;

        string playerName = playerInputText;
        if (string.IsNullOrEmpty(playerName))
            playerName = "Player";

        bestScore = score;
        bestPlayerName = playerName;

        PlayerPrefs.SetInt(BEST_SCORE_KEY, bestScore);
        PlayerPrefs.SetString(BEST_NAME_KEY, bestPlayerName);
        PlayerPrefs.Save();
        Debug.Log($"NEW BEST SAVED: {bestScore} by {bestPlayerName}");

        return true;
        

    }
    public string GetBestScoreText()
    {
        return $"Best Score : {bestPlayerName} : {bestScore}";
    }

    public void ResetBestScore()
    {
        bestScore = 0;
        bestPlayerName = "Player";

        PlayerPrefs.DeleteKey(BEST_SCORE_KEY);
        PlayerPrefs.DeleteKey(BEST_NAME_KEY);
        PlayerPrefs.Save();
    }

}
