using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameScore : MonoBehaviour
{

    public static GameScore Instance;
    [SerializeField] private TMP_Text _scoreText;

    private int _scoreValue;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance == this)
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int value)
    {
        if (value < 0) return;
        _scoreValue += value;

        _scoreText.text = _scoreValue.ToString();
    }
}
