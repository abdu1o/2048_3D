using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMerger : CubeMerger
{
    [SerializeField] private float _exploationRadius = 10f;


    public override void MergeCube(CubeUnit self, CubeUnit other)
    {
        var cubesInOverlapSphere = Physics.OverlapSphere(transform.position, _exploationRadius);

        foreach (var cube in cubesInOverlapSphere)
        {
            if (cube.TryGetComponent(out CubeUnit cubeUnit))
            {
                EnableMergeCube(false, cubeUnit);
                AddMergeValueToScore(cubeUnit);
            }
        }

        EnableMergeCube(false, self);

        InvokeCubeMerged(self.CubeNumber * 2);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _exploationRadius);  
    }
}
