using UnityEngine;

namespace AmayaTest.Data
{
    [System.Serializable]
    public struct IntPairValues
    {
        public int x;
        public int y;
    }
    
    [CreateAssetMenu (fileName = "new StagesSettings", menuName = "Stages Settings", order = 11)]
    public class StagesSettings : ScriptableObject
    {
        [SerializeField] 
        private IntPairValues[] _stageSizes;
        
        public IntPairValues[] StageSizes => _stageSizes;

        public int NumberOfStages => _stageSizes.Length;
    }
}
