using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class CubeMerger : MonoBehaviour, ICubeCollisionHandler
{
    [SerializeField] private CubeUnit _cubeUnit;
    [SerializeField] private float _minInputValueForMerge = 0.1f;
    [SerializeField] private float _tossForce = 0.5f;

    public event Action<int> OnCubeMerged;
    public event Action OnCubeHitted;

    [SerializeField] private AudioClip _mergeSound;
    private AudioSource _audioSource;

    void Start()
    {

    }

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        var impulseValue = _cubeUnit.Rigidbody.velocity.sqrMagnitude;

        if (collision.gameObject.TryGetComponent(out CubeUnit cubeUnit))
        {
            if (impulseValue > _minInputValueForMerge)
            {
                MergeCube(_cubeUnit, cubeUnit);
            }
            else
            {
                OnCubeHitted?.Invoke();
            }
        }
    }

    protected void PlayMergeSound()
    {
        _audioSource.volume = 0.5f;

        if (_mergeSound != null && _audioSource != null)
        {
            _audioSource.PlayOneShot(_mergeSound);
        }
    }

    protected void TossMergeCube()
    {
        var tossVector = new Vector3(0f, 1f, 0f);
        _cubeUnit.Rigidbody.AddForce(tossVector * _tossForce, ForceMode.Impulse);
    }

    protected void InvokeCubeMerged(int cubeNumber)
    {
        OnCubeMerged?.Invoke(cubeNumber);
    }

    protected void EnableMergeCube(bool enabled, CubeUnit cubeUnit)
    {
        cubeUnit.gameObject.SetActive(enabled);
        cubeUnit.CubeMerger.enabled = enabled;
    }

    protected void AddMergeValueToScore(CubeUnit cubeUnit)
    { 
        var mergeValue = cubeUnit.CubeNumber / 2;
        GameScore.Instance.AddScore(mergeValue);
    }

    public abstract void MergeCube(CubeUnit self, CubeUnit other);

}
