using System;
using UnityEngine;

namespace Tasks.ExplosionCubes
{
    [RequireComponent(typeof(SpawnerFragments))]
    public class Cube : MonoBehaviour, IExploding
    {
        [SerializeField] private float _splitChance = 100f;
        private float _splitChanceDivision = 2f;

        private int _minCountSplit;
        private int _maxCountSplit;

        public event Action Exploded;
        public event Action<int, int> Splited;

        private void Awake()
        {
            _minCountSplit = 2;
            _maxCountSplit = 6;
        }

        public void ExplodeSelf()
        {
            Exploded?.Invoke();

            if (CanSplit())
            {
                Splited?.Invoke(_minCountSplit, _maxCountSplit);
            }

            Destroy(gameObject);
        }

        public void ReduceSplitChance()
        {
            _splitChance /= _splitChanceDivision;
        }

        private bool CanSplit()
        {
            int minPercent = 0;
            int maxPercent = 100;

            return UnityEngine.Random.Range(minPercent, maxPercent) <= _splitChance;
        }
    }
}
