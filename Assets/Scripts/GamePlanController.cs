using System;
using System.Collections;
using AmayaTest.Data;
using AmayaTest.Grid;
using AmayaTest.UI;
using UnityEngine;

namespace AmayaTest
{
    public class GamePlanController : MonoBehaviour
    {
        [SerializeField] private float nextStageDelay = 1f;
        [SerializeField] private float inputDelay = 0.5f;
        
        [SerializeField] 
        private GamePlanFactory _factory;

        [SerializeField] 
        private GridController _grid;
        
        [SerializeField] 
        private GoalBar _goalUI;
        
        [SerializeField] 
        private RestartScreenController _restartUI;

        [SerializeField] 
        private InputManager _input;
        

        private int _currentStage;
        
        private GamePlanData _gamePlanData;

        private void Awake()
        {
            ResetLevels();
            _grid.OnRightAnswer += GetRightAnswer;
        }

        public void ResetLevels()
        {
            _gamePlanData = _factory.GetGamePlan();
            _currentStage = 0;
            MoveNextStage(true);
            _goalUI.FadeFromOpaque();
            _restartUI.TurnOff();
            StartCoroutine(DelayedInputTurn());
        }

        private void MoveNextStage(bool isStageFirst = false)
        {
            if (_currentStage > _gamePlanData.NumberOfStages - 1)
            {
                LevelsEnd();
                return;
            }

            StartCoroutine(DelayedInputTurn());
            _grid.SetStage(_gamePlanData.StageData[_currentStage], isStageFirst);
            _goalUI.SetGoal(_gamePlanData.StageData[_currentStage].AnswerData.Identifier);
            _currentStage++;
        }

        private void LevelsEnd()
        {
            _input.TurnOff();
            _restartUI.TurnOn();
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
            _input.TurnOff();
            yield return new WaitForSeconds(nextStageDelay);
            MoveNextStage(); ;
        }
        
        IEnumerator DelayedInputTurn()
        {
            yield return new WaitForSeconds(inputDelay);
            _input.TurnOn();
        }
    }
}
