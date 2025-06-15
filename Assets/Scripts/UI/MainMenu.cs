using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private UIDocument _uiDocument;

    private VisualElement _root;
    private Label _highScoreLabel;
    private Button _playButton;
    private Button _resetScoreButton;


    private void Awake()
    {
        _root = _uiDocument.rootVisualElement;

        _highScoreLabel = _root.Q<Label>("HIGHSCORE");
        _playButton = _root.Q<Button>("PlayButton");
        _resetScoreButton = _root.Q<Button>("ResetScoreButton");

        _highScoreLabel.text = $"HIGHSCORE: {GameScore.Instance.HighScoreValue}";

        _playButton.RegisterCallback<ClickEvent>(OnPlayButtonClicked);
        _resetScoreButton.RegisterCallback<ClickEvent>(OnResetScoreButtonClicked);
    }

    private void OnResetScoreButtonClicked(ClickEvent evt)
    {
        GameScore.Instance.ResetHighScore();
        _highScoreLabel.text = $"HIGHSCORE: {GameScore.Instance.HighScoreValue}";
    }

    private void OnPlayButtonClicked(ClickEvent evt)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
