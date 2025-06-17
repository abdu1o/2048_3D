using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalMerger : CubeMerger
{
    public override void MergeCube(CubeUnit self, CubeUnit other)
    {
        InvokeCubeMerged(other.CubeNumber * 2);
        EnableMergeCube(false, self);
        EnableMergeCube(false, other);
        AddMergeValueToScore(other);

        PlayMergeSound();
        TossMergeCube();
    }
}
