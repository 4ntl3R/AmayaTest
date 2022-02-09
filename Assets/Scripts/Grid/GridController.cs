using AmayaTest.Data;
using UnityEngine;

namespace AmayaTest.Grid
{
    public class GridController : MonoBehaviour
    {
        private StageData _stageData;

        public void SetStage(StageData newStage)
        {
            _stageData = newStage;
            DrawStage();
        }

        private void DrawStage()
        {
            
        }
    }
}
