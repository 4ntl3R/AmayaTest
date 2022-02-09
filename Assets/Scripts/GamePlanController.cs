using System;
using AmayaTest.Data;
using AmayaTest.Grid;
using UnityEngine;

namespace AmayaTest
{
    public class GamePlanController : MonoBehaviour
    {
        [SerializeField] 
        private GamePlanFactory _factory;

        [SerializeField] 
        private GridController _grid;

        private int _currentStage;
        
        private GamePlanData _gamePlanData;

        private void Awake()
        {
            ResetLevels();
        }

        private void ResetLevels()
        {
            _gamePlanData = _factory.GetGamePlan();
            _currentStage = 0;
            MoveNextStage();
        }

        private void MoveNextStage()
        {
            if (_currentStage >= _gamePlanData.NumberOfStages - 1)
            {
                LevelsEnd();
                return;
            }
            
            _grid.SetStage(_gamePlanData.StageData[_currentStage]);
            _currentStage++;
        }

        private void LevelsEnd()
        {
            
        }
    }
}
