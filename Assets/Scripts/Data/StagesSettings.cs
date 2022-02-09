using UnityEngine;

namespace AmayaTest.Data
{
    [System.Serializable]
    public struct IntPairValues
    {
        public int x;
        public int y;

        public IntPairValues(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    
    [CreateAssetMenu (fileName = "new StagesSettings", menuName = "Stages Settings", order = 11)]
    public sealed class StagesSettings : ScriptableObject
    {
        [SerializeField] 
        private IntPairValues[] _stageSizes;
        
        public IntPairValues[] StageSizes => _stageSizes;

        public int NumberOfStages => _stageSizes.Length;
    }
}