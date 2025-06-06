using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeThrower : CubeHandler
{
    [SerializeField] private float _throwForce = 2f;
    public event Action<CubeUnit> OnCubeThrown;

    protected override void OnPressCanceled()
    {
        if(cubeUnit == null) return;
        if (!cubeUnit.IsMainCube) return;

        cubeUnit.Rigidbody.AddForce(Vector3.back * _throwForce, ForceMode.Impulse);

        OnCubeThrown?.Invoke(cubeUnit);

        cubeUnit.SetMainCube(false);
        cubeUnit = null;

        base.OnPressCanceled();
    }
}
