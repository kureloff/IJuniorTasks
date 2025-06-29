using System;
using System.Collections;
using UnityEngine;

namespace Tasks.Counter
{
    public class CounterModel : MonoBehaviour
    {
        [SerializeField] private InputReader _inputReader;

        private int _count;
        private Coroutine _countingCoroutine;

        public event Action<int> ÑountChanged;

        private void Awake()
        {
            _count = 0;
        }

        private void OnEnable()
        {
            _inputReader.Clicked += ToggleCounter;
        }

        private void OnDisable()
        {
            _inputReader.Clicked -= ToggleCounter;
        }

        private void ToggleCounter()
        {
            if (_countingCoroutine == null)
            {
                _countingCoroutine = StartCoroutine(BeginCount());
            }
            else
            {
                StopCoroutine(_countingCoroutine);
                _countingCoroutine = null;
            }
        }

        private IEnumerator BeginCount()
        {
            float waitSeconds = 0.5f;
            WaitForSeconds waitForSeconds = new WaitForSeconds(waitSeconds);
            bool isBeginCount = true;

            while (isBeginCount)
            {
                _count++;
                ÑountChanged?.Invoke(_count);
                yield return waitForSeconds;
            }
        }
    }
}