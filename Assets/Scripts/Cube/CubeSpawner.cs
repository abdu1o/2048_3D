using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private CubeUnit _cubePrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private CubeThrower _cubeThrower;

    public event Action<CubeUnit> OnCubeSpawned;

    void OnEnable()
    {
        _cubeThrower.OnCubeThrown += OnCubeTrowed;
    }

    private void SpawnCube()
    {
        var newCube = Instantiate(_cubePrefab, _spawnPoint.position, Quaternion.identity, transform);
        newCube.SetMainCube(true);
        newCube.CubeViewer.SetCubeView();
        
        OnCubeSpawned?.Invoke(newCube);
    }

    private void Start()
    {
        SpawnCube();
    }

    void OnDisable()
    {
        _cubeThrower.OnCubeThrown -= OnCubeTrowed;
    }

    private void OnCubeTrowed(CubeUnit throwedCube)
    {
        StartCoroutine(WaitCubeStopped(throwedCube));
    }

    private IEnumerator WaitCubeStopped(CubeUnit cube)
    {
        const float delay = 0.1f;

        var cubeRigidBody = cube.Rigidbody;

        while (cubeRigidBody != null && !cubeRigidBody.IsSleeping())
        {
            yield return new WaitForSeconds(delay);
        }

        SpawnCube();
    }

}
