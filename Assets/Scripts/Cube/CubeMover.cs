using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMover : CubeHandler
{
    [SerializeField] private float _clampX;

    protected override void OnPerformedPointer()
    {
        base.OnPerformedPointer();
        MoveCube();
    }

    private void MoveCube()
    {   
        if(!cubeUnit.IsMainCube) return;

        var clampedPosition = Mathf.Clamp(mousePosition.x, -_clampX, _clampX);
        var newCubePosition = new Vector3(clampedPosition, cubeUnit.transform.position.y, cubeUnit.transform.position.z);

        cubeUnit.transform.position = newCubePosition;
    }
}