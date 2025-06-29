using UnityEngine;

namespace Tasks.ExplossionCubes
{
    public class SpawnerFragments : MonoBehaviour
    {
        private float _scaleDivision = 2f;

        public void Spawn(Cube cube, int minCount, int maxCount)
        {
            int count = Random.Range(minCount, maxCount);
            
            for (int i = 0; i < count; i++)
            {
                GameObject spawnObject = Instantiate(cube.gameObject);
                spawnObject.transform.localScale = ReduceScale(spawnObject.transform);

                Cube newCube = spawnObject.GetComponent<Cube>();
                newCube.SetSplitChance(newCube.SplitChance);
                ChangeColorMaterial(newCube.gameObject);
            }
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
