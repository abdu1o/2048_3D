using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeVFX : MonoBehaviour
{
    [SerializeField] private CubeUnit _cubeUnit;
    [SerializeField] private ParticleSystem _mergeVFX;
    [SerializeField] private ParticleSystem _hitVFX;


    private void OnEnable()
    {
        _cubeUnit.CubeMerger.OnCubeMerged += OnCubeMerged;
        _cubeUnit.CubeMerger.OnCubeHitted += OnCubeHitted;
    }

    private void OnDisable()
    {
        _cubeUnit.CubeMerger.OnCubeMerged -= OnCubeMerged;
        _cubeUnit.CubeMerger.OnCubeHitted -= OnCubeHitted;
    }

    private void OnCubeMerged(int value)
    {
        _mergeVFX.Play();
    }

    private void OnCubeHitted()
    {
        _hitVFX.Play();
    }
}
