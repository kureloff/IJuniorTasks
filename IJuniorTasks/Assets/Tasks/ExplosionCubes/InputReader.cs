using System;
using UnityEngine;

namespace Tasks.ExplosionCubes
{
    public class InputReader : MonoBehaviour
    {
        private Camera _camera;

        public event Action<RaycastHit> HitPointReceived;

        private void Awake()
        {
            _camera = GetComponent<Camera>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                ReceivingHitPoint();
            }
        }

        private void ReceivingHitPoint()
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = _camera.nearClipPlane;
            Ray ray = _camera.ScreenPointToRay(mousePosition);
            float rayDistance = 100.0f;

            if(Physics.Raycast(ray, out RaycastHit hit, rayDistance))
            {
                if(hit.collider)
                    HitPointReceived?.Invoke(hit);
            }
        }
    }
}
