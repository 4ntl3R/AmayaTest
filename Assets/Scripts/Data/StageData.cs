using UnityEngine;

namespace AmayaTest.Data
{
    
    public sealed class StageData
    {
        public StageData(CardData[,] gridData, IntPairValues answerIndex)
        {
            GridData = gridData;
            AnswerIndex = answerIndex;
        }

        public CardData[,] GridData { get; }
        public IntPairValues AnswerIndex { get; }

        public CardData AnswerData => GridData[AnswerIndex.x, AnswerIndex.y];
    }
}