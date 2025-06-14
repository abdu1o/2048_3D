using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameWinArea : MonoBehaviour
{
    [SerializeField] private int _pointsToWin = 32;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _scoreTextField;
    [SerializeField] private CanvasGroup _gameWinScreen;
    [SerializeField] private CanvasGroup _scoreScreen;
    [SerializeField] private CanvasGroup _timerScreen;
    [SerializeField] private CubeHandler _cubeHandler;

    private void Update()
    {
        if (int.Parse(_scoreText.text) >= _pointsToWin)
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

        _scoreTextField.text = "Score: " + _scoreText.text;

        EnableCanvasGroup(_gameWinScreen, 1f, true);

        EnableCanvasGroup(_scoreScreen, 0f, false);

        EnableCanvasGroup(_timerScreen, 0f, false);
    }
}
