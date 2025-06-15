using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameScore : MonoBehaviour
{

    public static GameScore Instance;

    private int _scoreValue;
    private int _highScoreValue;

    public event Action<int> OnScoreChanged;

    public int ScoreValue => _scoreValue;
    public int HighScoreValue => _highScoreValue;

    public void Initialize()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance == this)
        {
            Destroy(gameObject);
        }

        _highScoreValue = PlayerPrefs.GetInt("HighScore", 0);

        DontDestroyOnLoad(gameObject);
    }

    public void AddScore(int value)
    {
        if (value < 0) return;
        _scoreValue += value;

        if (_scoreValue > _highScoreValue)
        {
            _highScoreValue = _scoreValue;
            PlayerPrefs.SetInt("HighScore", _highScoreValue);
        }

        OnScoreChanged?.Invoke(_scoreValue);
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        _highScoreValue = 0;
    }

    public int GetScore()
    {
        return _scoreValue;
    }
}
