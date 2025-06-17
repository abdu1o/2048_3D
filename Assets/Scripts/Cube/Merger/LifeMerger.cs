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
            EnableMergeCube(false, other);
                
            AddMergeValueToScore(other);
                    
            TossMergeCube();

            _currentLives--;
        }
        else
        {
            EnableMergeCube(false, self);
                    
            AddMergeValueToScore(other);
                    
            InvokeCubeMerged(other.CubeNumber);
                    
            TossMergeCube();
        }
    }
}
