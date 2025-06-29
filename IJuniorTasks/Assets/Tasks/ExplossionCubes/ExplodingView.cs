using System;
using UnityEngine;

namespace Tasks.ExplossionCubes
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(SpawnerFragments))]
    [RequireComponent(typeof(ExplodingModel))]
    public class ExplodingView : MonoBehaviour, IExploding
    {
        private ExplodingModel _explodingModel;

        public event Action Exploded;

        private void Awake()
        {
            _explodingModel = GetComponent<ExplodingModel>();
        }

        public void ExplodeSelf()
        {
            Exploded?.Invoke();

            Destroy(transform.gameObject);
        }
    }
}
