using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMerger : MonoBehaviour
{
    [SerializeField] private CubeUnit _cubeUnit;
    [SerializeField] private float _minInputValueForMerge = 0.1f;
    [SerializeField] private float _tossForce = 0.5f;

    public event Action<int> OnCubeMerged;
    public event Action OnCubeHitted;

    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        var impulseValue = _cubeUnit.Rigidbody.velocity.sqrMagnitude;

        if (collision.gameObject.TryGetComponent(out CubeUnit cubeUnit))
        {
            if (cubeUnit.IsMainCube) return;
            if (cubeUnit.CubeNumber != _cubeUnit.CubeNumber) return;
            if (impulseValue < _minInputValueForMerge) return;

            cubeUnit.gameObject.SetActive(false);
            cubeUnit.CubeMerger.enabled = false;

            OnCubeMerged?.Invoke(cubeUnit.CubeNumber * 2);

            var mergeValue = _cubeUnit.CubeNumber / 2;
            GameScore.Instance.AddScore(mergeValue);

            TossMergeCube();
        }
        else
        {
            OnCubeHitted?.Invoke();
        }
    }

    private void TossMergeCube()
    {
        var tossVector = new Vector3(0f, 1f, 0f);
        _cubeUnit.Rigidbody.AddForce(tossVector * _tossForce, ForceMode.Impulse);
    }

}
