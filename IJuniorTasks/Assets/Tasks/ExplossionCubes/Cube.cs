using System.Collections.Generic;
using UnityEngine;

namespace Tasks.ExplossionCubes
{
    [RequireComponent(typeof(SpawnerFragments))]
    [RequireComponent(typeof(Rigidbody))]
    public class Cube : MonoBehaviour, IExploding
    {
        private SpawnerFragments _spawner;

        private float _explosionRadius;
        private float _explosionForce;

        private float _splitChance = 100.0f;
        private float _splitChanceDivision;
        private int _minCountSpawn;
        private int _maxCountSpawn;

        public float SplitChance => _splitChance;

        private void Awake()
        {
            _spawner = GetComponent<SpawnerFragments>();
            _splitChanceDivision = 2f;
            _explosionForce = 700.0f;
            _explosionRadius = 10.0f;
            _minCountSpawn = 2;
            _maxCountSpawn = 6;
        }

        public void SetSplitChance(float chance) =>
            _splitChance = chance / _splitChanceDivision;

        public void ExplodeSelf()
        {
            foreach (Rigidbody rigidbody in GetEnvieronmentObjects())
            {
                rigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
            }

            if (Random.Range(0, 100) <= _splitChance)
                _spawner.Spawn(this, 2, 6);

            Destroy(transform.gameObject);
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
