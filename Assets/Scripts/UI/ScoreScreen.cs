using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _highScoreText;

    void OnEnable()
    {
        GameScore.Instance.OnScoreChanged += OnScoreChanged;
        GameScore.Instance.OnHighScoreChanged += OnHighScoreChanged;

        ShowScores(_highScoreText, GameScore.Instance.HighScoreValue);
    }

    private void OnScoreChanged(int scoreValue)
    {
        ShowScores(_scoreText, scoreValue);
    }

    private void OnHighScoreChanged(int highScoreValue)
    {
        ShowScores(_highScoreText, highScoreValue);
    }

    void OnDisable()
    {
        GameScore.Instance.OnScoreChanged -= OnScoreChanged;
        GameScore.Instance.OnHighScoreChanged -= OnHighScoreChanged;

    }

    private void ShowScores(TMP_Text scoreText, int value)
    {
        scoreText.text = value.ToString();
    }
}
