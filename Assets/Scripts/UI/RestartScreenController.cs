using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace AmayaTest.UI
{
    public class RestartScreenController : MonoBehaviour
    {
        [SerializeField] 
        private Image _screenPanel;
        
        [SerializeField]
        private Button _button;

        public void TurnOn()
        {
            _button.gameObject.SetActive(true);
            _screenPanel.DOFade(0.9f, 3f);
        }
    
        public void TurnOff()
        {
            _button.gameObject.SetActive(false);
            _screenPanel.DOFade(0f, 3f);
        }
    }
}
