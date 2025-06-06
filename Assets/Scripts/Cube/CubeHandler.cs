using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHandler : MonoBehaviour
{

    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private CubeSpawner _cubeSpawner;

    protected CubeUnit cubeUnit;
    protected Vector3 mousePosition;

    void OnEnable()
    {   
        _cubeSpawner.OnCubeSpawned += OnCubeSpawned;
        _inputHandler.OnPressStarted += OnPressStarted;
        _inputHandler.OnPressCanceled += OnPressCanceled;
    }

    void OnCubeSpawned(CubeUnit newCube)
    {
        cubeUnit = newCube;
    }

    void OnDisable()
    {
        _cubeSpawner.OnCubeSpawned -= OnCubeSpawned;
        _inputHandler.OnPressStarted -= OnPressStarted;
        _inputHandler.OnPressCanceled -= OnPressCanceled;
    }

    protected virtual void OnPressStarted()
    {
        if(cubeUnit == null) return;
        
        _inputHandler.OnPerformedPointer += OnPerformedPointer;
    }

    protected virtual void OnPerformedPointer()
    {   
        if(cubeUnit == null) return;
        mousePosition = _inputHandler.GetTouchPosition(cubeUnit.transform);
    }
    
    protected virtual void OnPressCanceled()
    {
        _inputHandler.OnPerformedPointer -= OnPerformedPointer;
    }
}
