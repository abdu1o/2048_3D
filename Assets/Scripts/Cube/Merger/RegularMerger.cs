using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularMerger : CubeMerger
{
    public override void MergeCube(CubeUnit self, CubeUnit other)
    {
        if (self.CubeNumber == other.CubeNumber)
        {
            EnableMergeCube(false, other);

            InvokeCubeMerged(self.CubeNumber * 2);

            AddMergeValueToScore(self);

            PlayMergeSound();
            TossMergeCube();
        }
    }
}
