using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;

    private ScreenTouch _screenTouch;

    public event Action OnPressStarted;
    public event Action OnPerformedPointer;
    public event Action OnPressCanceled;

    private void Awake()
    {
        _screenTouch = new ScreenTouch();

        _screenTouch.Player.PressScreen.started += _ => OnPressStarted?.Invoke();
        _screenTouch.Player.PressScreen.canceled += _ => OnPressCanceled?.Invoke();
        _screenTouch.Player.PressScreen.performed += _ => OnPerformedPointer?.Invoke();
    }

    private void OnEnable()
    {
        _screenTouch.Player.Enable();
    }

    private void OnDisable ()
    {
        _screenTouch.Player.Disable();
    }

    public Vector3 GetTouchPosition(Transform cubeTransform)
    {
        var depth = Vector3.Distance(_mainCamera.transform.position, cubeTransform.position);
        var screenPosition = _screenTouch.Player.TouchPosition.ReadValue<Vector2>();

        return _mainCamera.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, depth));
    }
}
