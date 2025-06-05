using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeThrower : CubeHandler
{
    [SerializeField] private float _throwForce = 10f;

    protected override void OnPressCanceled()
    {
        if(!cubeUnit.IsMainCube) return;

        cubeUnit.Rigidbody.AddForce(Vector3.forward * _throwForce, ForceMode.Impulse);
        cubeUnit.SetMainCube(false);

        base.OnPressCanceled();
    }
}
