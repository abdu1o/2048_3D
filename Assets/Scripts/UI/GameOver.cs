using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameOverArea _gameOverArea;
    [SerializeField] private CanvasGroup _gameOverScreen;
    [SerializeField] private CanvasGroup _scoreScreen;
    [SerializeField] private CanvasGroup _timerScreen;
    [SerializeField] private CubeHandler _cubeHandler;
    [SerializeField] private TMP_Text _timerText;

    void OnEnable()
    {
        _gameOverArea.OnGameOver += OnGameOver;
        _gameOverArea.OnTimeToLoseChanged += OnTimeToLoseChanged;
        _gameOverArea.OnTimerStarted += OnTimeStarted;
        _gameOverArea.OnTimerStopped += OnTimeStopped;
    }

    private void OnTimeStopped()
    {
        EnableCanvasGroup(_timerScreen, 0f, false);
    }

    private void OnTimeStarted()
    {
        EnableCanvasGroup(_timerScreen, 1f, true);
    }

    private void OnTimeToLoseChanged(float time)
    {
        _timerText.text = $"Time to lose: {Mathf.CeilToInt(time)}";
    }

    private void OnGameOver()
    {
        _cubeHandler.gameObject.SetActive(false);

        EnableCanvasGroup(_gameOverScreen, 1f, true);

        EnableCanvasGroup(_scoreScreen, 0f, false);

        EnableCanvasGroup(_timerScreen, 0f, false);
    }

    private void EnableCanvasGroup(CanvasGroup canvasGroup, float alpha, bool interactable)
    {
        canvasGroup.alpha = alpha;
        canvasGroup.interactable = interactable;
    }

    void OnDisable()
    {
        _gameOverArea.OnGameOver -= OnGameOver;
        _gameOverArea.OnTimeToLoseChanged -= OnTimeToLoseChanged;
        _gameOverArea.OnTimerStarted -= OnTimeStarted;
        _gameOverArea.OnTimerStopped -= OnTimeStopped;
    }
}
