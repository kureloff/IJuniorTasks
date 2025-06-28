using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Tasks.Counter
{
    public class Counter : MonoBehaviour
    {
        private TMP_Text _text;

        private int _count;
        private bool _isBeginCount;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
            _count = 0;
            _isBeginCount = false;

            _text.text = _count.ToString();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _isBeginCount = !_isBeginCount;

                if (_isBeginCount)
                {
                    StartCoroutine(BeginCount());
                }
                else
                {
                    StopCoroutine(BeginCount());
                }
            }
        }

        private IEnumerator BeginCount()
        {
            while (_isBeginCount)
            {
                _count++;
                _text.text = _count.ToString();

                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}
