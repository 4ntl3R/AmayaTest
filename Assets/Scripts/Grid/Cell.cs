using UnityEngine;

namespace AmayaTest.Grid
{
    public enum CellAnimationType
    {
        Bounce,
        Shake,
    }
    
    public class Cell : MonoBehaviour
    {
        [SerializeField] 
        private SpriteRenderer _visualsRenderer;

        public void SetCell(Sprite sprite)
        {
            _visualsRenderer.sprite = sprite;
        }
    }
}
