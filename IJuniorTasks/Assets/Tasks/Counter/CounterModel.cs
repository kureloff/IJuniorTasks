using System;
using System.Collections;
using UnityEngine;

public class CounterModel : MonoBehaviour
{
    public event Action<int> OnCountChanged;

    [SerializeField] private InputReader _inputReader;

    private int _count;
    private bool _isBeginCount;

    private void Awake()
    {
        _count = 0;
        _isBeginCount = false;
    }

    private void OnEnable()
    {
        _inputReader.OnClick += ToggleCounter;
    }

    private void OnDisable()
    {
        _inputReader.OnClick -= ToggleCounter;
    }

    private void ToggleCounter()
    {
        if(_isBeginCount == false)
        {
            _isBeginCount = true;
            StartCoroutine(BeginCount());
        }
        else
        {
            _isBeginCount = false;
            StopCoroutine(BeginCount());
        }
    }

    private IEnumerator BeginCount()
    {
        while (_isBeginCount)
        {
            _count++;
            OnCountChanged?.Invoke(_count);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
