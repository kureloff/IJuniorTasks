using UnityEngine;

namespace Tasks.ExplosionCubes
{
    public class Exploder : MonoBehaviour
    {
        [SerializeField] private InputReader _inputReader;

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

                exploding.ExplodeSelf();
            }
        }
    }
}
