using UnityEngine;

namespace Tasks.ExplosionCubes
{
    public class ColorChanger
    {
        public void ChangeColorMaterial(GameObject spawnObject)
        {
            Color color = new Color(Random.value, Random.value, Random.value);
            Renderer renderer = spawnObject.GetComponent<Renderer>();

            renderer.material.color = color;
        }
    }
}
