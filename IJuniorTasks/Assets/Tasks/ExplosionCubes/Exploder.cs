using UnityEngine;

namespace Tasks.ExplosionCubes
{
    public class Exploder : MonoBehaviour
    {
        [SerializeField] private InputReader _inputReader;

        [SerializeField] private float _originalExplosionForce = 100;
        [SerializeField] private float _originalExplosionRadius = 10;

        private void OnEnable()
        {
            _inputReader.HitPointReceived += Explode;
        }

        private void OnDisable()
        {
            _inputReader.HitPointReceived -= Explode;
        }

        private void Explode(RaycastHit hit)
        {
            IExploding exploding;

            if (hit.collider)
            {
                exploding = hit.collider.GetComponent<IExploding>();

                if (exploding == null)
                    return;

                Rigidbody targetRigidbody = hit.collider.GetComponent<Rigidbody>();

                if (targetRigidbody != null)
                    AddExplosionForceToObject(targetRigidbody);

                exploding.ExplodeSelf();
            }
        }

        private void AddExplosionForceToObject(Rigidbody targetRigidbody)
        {
            float explosionForce = targetRigidbody.transform.localScale.x * _originalExplosionForce;
            float explosionRadius = targetRigidbody.transform.localScale.x * _originalExplosionRadius;

            Collider[] colliders = Physics.OverlapSphere(targetRigidbody.position, explosionRadius);

            foreach (Collider hit in colliders)
            {
                Rigidbody rigidbody = hit.GetComponent<Rigidbody>();

                if(rigidbody != null)
                {
                    rigidbody.AddExplosionForce(explosionForce, targetRigidbody.position, explosionRadius);
                }
            }
        }
    }
}
