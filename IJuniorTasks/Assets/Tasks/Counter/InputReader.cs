using System;
using UnityEngine;

namespace Tasks.Counter
{
    public class InputReader : MonoBehaviour
    {
        public event Action Clicked;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Clicked?.Invoke();
            }
        }
    }
}