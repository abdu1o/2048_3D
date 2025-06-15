using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    [SerializeField] private Button _restartButton;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(() => ReloadScene());
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveAllListeners();
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(2);
    }
}
