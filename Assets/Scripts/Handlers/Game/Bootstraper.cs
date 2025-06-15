using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstraper : MonoBehaviour
{
    [SerializeField] private GameScore _gameScore;
    void Awake()
    {
        _gameScore.Initialize();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
