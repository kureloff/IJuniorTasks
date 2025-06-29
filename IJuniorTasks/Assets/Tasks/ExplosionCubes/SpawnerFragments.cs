using UnityEngine;

namespace Tasks.ExplosionCubes
{
    public class SpawnerFragments : MonoBehaviour
    {
        private Cube _cube;
        private ColorChanger _colorChanger;

        private float _scaleDivision;

        private void Awake()
        {
            _cube = GetComponent<Cube>();
            _colorChanger = new ColorChanger();
            _scaleDivision = 2f;
        }

        private void OnEnable()
        {
            _cube.Splited += Spawn;
        }

        private void OnDisable()
        {
            _cube.Splited -= Spawn;
        }

        private void Spawn(int minCount, int maxCount)
        {
            int count = Random.Range(minCount, maxCount);

            _cube.ReduceSplitChance();

            for (int i = 0; i < count; i++)
            {
                GameObject spawnObject = Instantiate(_cube.transform.gameObject);
                spawnObject.transform.localScale = ReduceScale(spawnObject.transform);
                _colorChanger.ChangeColorMaterial(spawnObject.gameObject);
            }
        }

        private Vector3 ReduceScale(Transform transformReduce) =>
            transformReduce.localScale /= _scaleDivision;

        
    }
}
