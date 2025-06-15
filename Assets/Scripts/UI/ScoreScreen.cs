using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    void OnEnable()
    {
        GameScore.Instance.OnScoreChanged += OnScoreChanged;
    }

    private void OnScoreChanged(int scoreValue)
    {
        _scoreText.text = scoreValue.ToString();
    }

    void OnDisable()
    {
        GameScore.Instance.OnScoreChanged -= OnScoreChanged;
    }
}
