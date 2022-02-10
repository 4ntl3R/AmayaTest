using System;
using System.Collections;
using UnityEngine;

namespace AmayaTest
{
    public class InputManager : MonoBehaviour
    {
        public event Action<Vector3> OnInput;

        [SerializeField] 
        private float clickDeltaTime = 0.5f;
        
        private Camera _camera;

        private bool _isTurnedOn = false;

        private float lastClick = 0f;

        private void Awake()
        {
            _camera = Camera.main;
        }

        public void TurnOn()
        {
            if (_isTurnedOn)
                return;

            _isTurnedOn = true;
            StartCoroutine(InputProcess());
        }

        public void TurnOff()
        {
            if (!_isTurnedOn)
                return;

            _isTurnedOn = false;
            StopCoroutine(InputProcess());
        }

        IEnumerator InputProcess()
        {
            while (_isTurnedOn)
            {
                if (Input.GetMouseButtonDown(0) && (Time.realtimeSinceStartup - lastClick > clickDeltaTime))
                {
                    OnInput?.Invoke(GetInputPosition());
                    lastClick = Time.realtimeSinceStartup;
                }
                yield return null;
            }
        }

        private Vector3 GetInputPosition()
        {
            return _camera.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}