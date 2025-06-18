using System.Collections;
using System.Collections.Generic;
using Cube;
using TMPro;
using UI;
using UnityEngine;

public class GameWinArea : MonoBehaviour
{
    [SerializeField] private int _pointsToWin = 32;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private CanvasGroup _gameWinScreen;
    [SerializeField] private CanvasGroup _scoreScreen;
    [SerializeField] private CanvasGroup _timerScreen;
    [SerializeField] private CubeHandler _cubeHandler;
    [SerializeField] private TMP_Text _highScoreText;

    private void Update()
    {
        if (GameScore.Instance.ScoreValue >= _pointsToWin)
        {
            Win();
        }
    }

    private void EnableCanvasGroup(CanvasGroup canvasGroup, float alpha, bool interactable)
    {
        canvasGroup.alpha = alpha;
        canvasGroup.interactable = interactable;
    }

    private void Win()
    {
        _cubeHandler.gameObject.SetActive(false);

        EnableCanvasGroup(_gameWinScreen, 1f, true);

        EnableCanvasGroup(_scoreScreen, 0f, false);

        EnableCanvasGroup(_timerScreen, 0f, false);

        _scoreText.text = $"Score: {GameScore.Instance.ScoreValue}";
        _highScoreText.text = $"HIGHSCORE: {GameScore.Instance.HighScoreValue}";
    }
}
