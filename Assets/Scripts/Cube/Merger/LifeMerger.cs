using Cube;
using Cube.Merger;
using UnityEngine;

public class LifeMerger : CubeMerger
{
    [SerializeField] private int _maxLives = 3;
    private int _currentLives;

    private void Start()
    {
        _currentLives = _maxLives;
    }

    public override void MergeCube(CubeUnit self, CubeUnit other)
    {
        if (_currentLives > 1)
        {
            EnableMergeCube(other, false);

            AddMergeValueToScore(other);

            TossMergeCube(other);

            _currentLives--;
        }
        else
        {
            EnableMergeCube(self, false);

            AddMergeValueToScore(other);

            InvokeCubeMerged(other.CubeNumber);

            TossMergeCube(other);
        }
    }
}
