using System;

using UnityEngine;

namespace AmayaTest
{
    public class InputManager : MonoBehaviour
    {
        public event Action<Vector3> OnInput;
        private Camera camera;

        private void Awake()
        {
            camera = Camera.main;
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnInput?.Invoke(GetInputPosition());
            }
        }

        private Vector3 GetInputPosition()
        {
            return camera.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}