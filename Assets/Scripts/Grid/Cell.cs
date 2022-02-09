using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;

namespace AmayaTest.Grid
{
    public enum AnimationType
    {
        Bounce,
        Shake,
    }
    
    public class Cell : MonoBehaviour
    {
        public const float ANIMATION_DURATION = 0.5f;
        public const float BOUNCE_SCALE = 0.25f;
        public const int BOUNCE_VIBRATIO = 10;
        public const float BOUNCE_ELASTICITY = 1f;
        public const float SHAKE_SCALE = 1f;
        public const int SHAKE_VIBRATIO = 10;
        public const float SHAKE_RANDOMNESS = 45f;


        [SerializeField] 
        private SpriteRenderer _visualsRenderer;

        private float lastAnimationStart = -ANIMATION_DURATION;

        public void SetCell(Sprite sprite)
        {
            _visualsRenderer.sprite = sprite;
        }
        

        public void Animate(AnimationType animationType = AnimationType.Shake)
        {
            if (Time.realtimeSinceStartup - lastAnimationStart <= ANIMATION_DURATION)
                return;
            
            if (animationType == AnimationType.Bounce)
                Bounce();
            else
                Shake();

            lastAnimationStart = Time.realtimeSinceStartup;
        }

        private void Bounce()
        {
            _visualsRenderer.transform.DOPunchScale(new Vector3(BOUNCE_SCALE, BOUNCE_SCALE), ANIMATION_DURATION, BOUNCE_VIBRATIO, BOUNCE_ELASTICITY);
        }

        private void Shake()
        {
            _visualsRenderer.transform.DOShakePosition(ANIMATION_DURATION, new Vector3(SHAKE_SCALE, 0, 0),
                SHAKE_VIBRATIO, SHAKE_RANDOMNESS);
        }
    }
}
