using System.Collections.Generic;
using UnityEngine;

namespace Tasks.ExplosionCubes
{
    public class ExplodingModel : MonoBehaviour
    {
        private ExplodingView _explodingView;

        private float _explosionRadius;
        private float _explosionForce;

        private void Awake()
        {
            _explodingView = GetComponent<ExplodingView>();
            _explosionForce = 700.0f;
            _explosionRadius = 10.0f;
        }

        private void OnEnable()
        {
            _explodingView.Exploded += Explode;
        }

        private void OnDisable()
        {
            _explodingView.Exploded += Explode;
        }

        private void Explode()
        {
            foreach (Rigidbody rigidbody in GetEnvieronmentObjects())
            {
                rigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
            }
        }

        private List<Rigidbody> GetEnvieronmentObjects()
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

            List<Rigidbody> envieronmentObjects = new();

            foreach (Collider hit in hits)
                if (hit.attachedRigidbody != null)
                    envieronmentObjects.Add(hit.attachedRigidbody);

            return envieronmentObjects;
        }
    }
}
