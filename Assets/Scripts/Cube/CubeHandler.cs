using System.Collections;
using System.Collections.Generic;
using Cube;
using UnityEngine;

public class CubeHandler : MonoBehaviour
{

    [SerializeField] private InputHandler _inputHandler;

    [SerializeField] protected CubeUnit cubeUnit;
    protected Vector3 mousePosition;

    void OnEnable()
    {
        _inputHandler.OnPressStarted += OnPressStarted;
        _inputHandler.OnPressCanceled += OnPressCanceled;
    }

    void OnDisable()
    {
        _inputHandler.OnPressStarted -= OnPressStarted;
        _inputHandler.OnPressCanceled -= OnPressCanceled;
    }

    protected virtual void OnPressStarted()
    {
        _inputHandler.OnPerformedPointer += OnPerformedPointer;
    }

    protected virtual void OnPerformedPointer()
    {
            mousePosition = _inputHandler.GetTouchPosition(cubeUnit.transform);
    }
    
    protected virtual void OnPressCanceled()
    {
        _inputHandler.OnPerformedPointer -= OnPerformedPointer;
    }
}
