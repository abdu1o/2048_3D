using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CubeViewer : MonoBehaviour
{
    [SerializeField] private CubeUnit _cubeUnit;
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private List<TMP_Text> _numberTexts;


    public void SetCubeView()
    {
        var cubeNumber = _cubeUnit.CubeUnitData.CubeNumber();

        _cubeUnit.SetCubeNumber(cubeNumber);

        foreach (var numberText in _numberTexts)
        {
            numberText.text = _cubeUnit.CubeNumber.ToString();
        }

        var cubeColor = _cubeUnit.CubeUnitData.CubeColor(cubeNumber);
        _meshRenderer.material.color = cubeColor;
    }
}
