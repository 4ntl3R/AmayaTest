using System;
using System.Collections;
using UnityEngine;

namespace AmayaTest
{
    public class InputManager : MonoBehaviour
    {
        public event Action<Vector3> OnInput;
        
        private Camera _camera;

        private bool _isTurnedOn = false;

        private void Awake()
        {
            _camera = Camera.main;
            TurnOn();
        }

        private void TurnOn()
        {
            if (_isTurnedOn)
                return;
            
            _isTurnedOn = true;
            StartCoroutine(InputProcess());
        }

        private void TurnOff()
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
                if (Input.GetMouseButtonDown(0))
                {
                    OnInput?.Invoke(GetInputPosition());
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