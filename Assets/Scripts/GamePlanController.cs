using System;
using System.Collections;
using AmayaTest.Data;
using AmayaTest.Grid;
using UnityEngine;

namespace AmayaTest
{
    public class GamePlanController : MonoBehaviour
    {
        [SerializeField] private float nextStageDelay = 1f;
        
        [SerializeField] 
        private GamePlanFactory _factory;

        [SerializeField] 
        private GridController _grid;
        
        [SerializeField] 
        private GoalBar _goalUI;
        

        private int _currentStage;
        
        private GamePlanData _gamePlanData;

        private void Awake()
        {
            ResetLevels();
            _grid.OnRightAnswer += GetRightAnswer;
        }

        private void ResetLevels()
        {
            _gamePlanData = _factory.GetGamePlan();
            _currentStage = 0;
            MoveNextStage(true);
            _goalUI.FadeFromOpaque();
        }

        private void MoveNextStage(bool isStageFirst = false)
        {
            if (_currentStage > _gamePlanData.NumberOfStages - 1)
            {
                LevelsEnd();
                return;
            }
            _grid.SetStage(_gamePlanData.StageData[_currentStage], isStageFirst);
            _goalUI.SetGoal(_gamePlanData.StageData[_currentStage].AnswerData.Identifier);
            _currentStage++;
        }

        private void LevelsEnd()
        {
            Debug.Log("REstart");
        }

        private void OnDestroy()
        {
            _grid.OnRightAnswer -= GetRightAnswer;
        }

        private void GetRightAnswer()
        {
            StartCoroutine(DelayedNextStage());
        }

        IEnumerator DelayedNextStage()
        {
            yield return new WaitForSeconds(nextStageDelay);
            MoveNextStage();
        }
    }
}
