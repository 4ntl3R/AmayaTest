using UnityEngine;

namespace AmayaTest.Data
{
    public sealed class GamePlanData 
    {
        public GamePlanData(StageData[] stageData)
        {
            StageData = stageData;
        }

        public StageData[] StageData { get; }
        
        public int NumberOfStages => StageData.Length;
    }
}