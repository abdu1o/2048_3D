using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWin : MonoBehaviour
{
    [SerializeField] private GameOverArea _gameOverArea;
    [SerializeField] private CanvasGroup _gameOverScreen;
    [SerializeField] private CanvasGroup _scoreScreen;
    [SerializeField] private CanvasGroup _timerScreen;
    [SerializeField] private CubeHandler _cubeHandler;
    [SerializeField] public int _pointToWin;

    
}
