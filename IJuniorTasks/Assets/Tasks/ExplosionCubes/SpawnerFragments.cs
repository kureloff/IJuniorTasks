using UnityEngine;

namespace Tasks.ExplosionCubes
{
    public class SpawnerFragments : MonoBehaviour
    {
        [SerializeField] private float _splitChance = 100;

        private ExplodingView _exploding;

        private float _scaleDivision;
        private float _splitDivision;

        private void Awake()
        {
            _exploding = GetComponent<ExplodingView>();
            _scaleDivision = 2f;
            _splitDivision = 2f;
        }

        private void OnEnable()
        {
            _exploding.Exploded += Spawn;
        }

        private void OnDisable()
        {
            _exploding.Exploded -= Spawn;
        }

        private void Spawn()
        {
            if (CanSplit() == false)
                return;

            int minCount = 2;
            int maxCount = 6;

            int count = Random.Range(minCount, maxCount);

            _splitChance /= _splitDivision;

            for (int i = 0; i < count; i++)
            {
                GameObject spawnObject = Instantiate(transform.gameObject);
                spawnObject.transform.localScale = ReduceScale(spawnObject.transform);
                ChangeColorMaterial(spawnObject.gameObject);
            }
        }

        private bool CanSplit()
        {
            int minPercent = 0;
            int maxPercent = 100;

            return Random.Range(minPercent, maxPercent) <= _splitChance;
        }

        private Vector3 ReduceScale(Transform transformReduce) =>
            transformReduce.localScale /= _scaleDivision;

        private void ChangeColorMaterial(GameObject spawnObject)
        {
            Color color = new Color(Random.value, Random.value, Random.value);
            Renderer renderer = spawnObject.GetComponent<Renderer>();

            renderer.material.color = color;
        }
    }
}
