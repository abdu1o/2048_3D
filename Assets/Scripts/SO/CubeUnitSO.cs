using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CubeUnitSO", menuName = "CubeUnitData", order = 0)]
public class CubeUnitSO : ScriptableObject
{
    [SerializeField] private List<Color> _colors;
    [SerializeField] private List<int> _chances;

    public int CubeNumber()
    {
        var roll = Random.Range(0, 100);
        var cumulative = 0;

        for (int i = 0; i < _chances.Count; i++)
        {
            cumulative += _chances[i];
            if (roll < cumulative)
            {
                return (int)Mathf.Pow(2, i + 1);
            }
        }
        return (int)Mathf.Pow(2, _chances.Count);
    }

    public Color CubeColor(int cubeNumber)
    {
        var colorIndex = (int)Mathf.Log(cubeNumber, 2) - 1;

        return _colors[colorIndex];
    }

}
