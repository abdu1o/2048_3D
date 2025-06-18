using System;
using System.Collections;
using System.Collections.Generic;
using Cube;
using Handlers.Game;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameOverArea _gameOverArea;
    [SerializeField] private CanvasGroup _gameOverScreen;
    [SerializeField] private CanvasGroup _gameScreen;
    [SerializeField] private CanvasGroup _timerScreen;
    [SerializeField] private CubeHandler _cubeHandler;
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _highScoreText;

    void OnEnable()
    {
        _gameOverArea.OnGameOver += OnGameOver;
        _gameOverArea.OnTimeToLoseChanged += OnTimeToLoseChanged;
        _gameOverArea.OnTimerStarted += OnTimeStarted;
        _gameOverArea.OnTimerStopped += OnTimeStopped;
    }

    private void OnTimeStopped()
    {
        EnableCanvasGroup(_timerScreen, 0f, false, false);
    }

    private void OnTimeStarted()
    {
        EnableCanvasGroup(_timerScreen, 1f, true, false);
    }

    private void OnTimeToLoseChanged(float time)
    {
        _timerText.text = $"Time to lose: {Mathf.CeilToInt(time)}";
    }

    private void OnGameOver()
    {
        _cubeHandler.gameObject.SetActive(false);

        EnableCanvasGroup(_gameOverScreen, 1f, true, true);

        EnableCanvasGroup(_gameScreen, 0f, false, false);

        EnableCanvasGroup(_timerScreen, 0f, false, false);

        _scoreText.text = $"Score: {GameScore.Instance.ScoreValue}";
        _highScoreText.text = $"HIGHSCORE: {GameScore.Instance.HighScoreValue}";
    }

    private void EnableCanvasGroup(CanvasGroup canvasGroup, float alpha, bool interactable, bool blockRaycasts)
    {
        canvasGroup.alpha = alpha;
        canvasGroup.interactable = interactable;
        canvasGroup.blocksRaycasts = blockRaycasts;
    }

    void OnDisable()
    {
        _gameOverArea.OnGameOver -= OnGameOver;
        _gameOverArea.OnTimeToLoseChanged -= OnTimeToLoseChanged;
        _gameOverArea.OnTimerStarted -= OnTimeStarted;
        _gameOverArea.OnTimerStopped -= OnTimeStopped;
    }
}
