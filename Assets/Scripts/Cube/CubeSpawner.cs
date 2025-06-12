using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private CubeUnit _cubePrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private CubeThrower _cubeThrower;

    private List<CubeUnit> _cubeUnits = new List<CubeUnit>();

    public event Action<CubeUnit> OnCubeSpawned;

    void OnEnable()
    {
        _cubeThrower.OnCubeThrown += OnCubeTrowed;
    }

private void SpawnCube()
{
    Quaternion rotation = Quaternion.Euler(0f, 180f, 0f);
    var newCube = Instantiate(_cubePrefab, _spawnPoint.position, rotation, transform);

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
        const float timeout = 1f;

        var cubeRigidBody = cube.Rigidbody;
        var timer = 0f;

        while (cubeRigidBody != null && !cubeRigidBody.IsSleeping())
        {
            yield return new WaitForSeconds(delay);

            timer += delay;

            if (timer >= timeout)
            {
                break;
            }
        }

        cube.CubeMerger.enabled = true;

        TakeCubeFromPool();
    }

    private void ResetCube(CubeUnit cubeUnit)
    {
        cubeUnit.SetMainCube(false);
        cubeUnit.transform.position = _spawnPoint.position;
        cubeUnit.transform.rotation = _spawnPoint.rotation;

        cubeUnit.Rigidbody.velocity = Vector3.zero;
        cubeUnit.Rigidbody.angularVelocity = Vector3.zero;

        cubeUnit.CubeMerger.enabled = false;
    }


    private void TakeCubeFromPool()
    {
        for (int i = 0; i < _cubeUnits.Count; i++)
        {
            var cubeUnit = _cubeUnits[i];

            if (!cubeUnit.gameObject.activeSelf)
            {
                ResetCube(cubeUnit);

                cubeUnit.gameObject.SetActive(true);
                cubeUnit.SetMainCube(true);
                cubeUnit.CubeViewer.SetCubeView();

                OnCubeSpawned?.Invoke(cubeUnit);

                return;
            }
        }

        SpawnCube();
    }

}
