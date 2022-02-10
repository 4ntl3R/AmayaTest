using System;
using AmayaTest.Data;
using UnityEngine;

namespace AmayaTest.Grid
{
    public class GridController : MonoBehaviour
    {
        public event Action OnRightAnswer;
        
        [SerializeField] 
        private Cell _cellPrefab;

        [SerializeField] 
        private InputManager _input;

        [SerializeField] 
        private ParticleSystem _particleSystem;
        
        private Cell[,] _cells;
        
        private float _gridHorizontalDist;
        private float _gridVerticalDist;
        
        private StageData _stageData;

        private bool _isInited = false;

        private void Init()
        {
            var cellSize = _cellPrefab.GetComponent<SpriteRenderer>().bounds.size;
            _gridHorizontalDist = cellSize.x;
            _gridVerticalDist = cellSize.y;
            _isInited = true;
            _input.OnInput += GridClicked;
        }
        

        public void SetStage(StageData newStage, bool animateGrid = false)
        {
            if (!_isInited)
            {
                Init();
            }
            _stageData = newStage;
            DrawStage(animateGrid);
        }

        private void DrawStage(bool animateGrid)
        {
            TryClearGrid();
            
            var xSize = _stageData.GridData.GetLength(0);
            var ySize = _stageData.GridData.GetLength(1);
            _cells = new Cell[xSize, ySize];
            
            for (var i = 0; i < xSize; i++) 
                for (int j = 0; j < ySize; j++)
                {
                    var coords = GetCellPosition(i, j, xSize, ySize);
                    var cellGameObject = Instantiate(_cellPrefab.gameObject, coords, Quaternion.identity, transform);
                    var cell = cellGameObject.GetComponent<Cell>();
                    cell.SetCell(_stageData.GridData[i, j].Sprite);
                    _cells[i, j] = cell;
                }

            if (!animateGrid)
                return;
            
            for (var i = 0; i < xSize; i++)
                for (int j = 0; j < ySize; j++)
                {
                    _cells[i, j].CellAnimate();
                }
        }

        private Vector3 GetCellPosition(int xIndex, int yIndex, int xSize, int ySize)
        {
            var xCoord = _gridHorizontalDist * (xIndex - (float)(xSize - 1) / 2);
            var yCoord = _gridVerticalDist * (yIndex - (float)(ySize - 1) / 2);
            return new Vector3(xCoord, yCoord);
        }
        
        private bool TryClearGrid()
        {
            if (_cells == null)
                return false;

            foreach (var cell in _cells)
            {
                Destroy(cell.gameObject);
            }

            return true;
        }

        private void OnDestroy()
        {
            _input.OnInput -= GridClicked;
        }

        private void GridClicked(Vector3 clickPosition)
        {
            if (TryWorldToCell(clickPosition, out var xIndex, out var yIndex))
            {
                var cell = _cells[xIndex, yIndex];
                if (xIndex == _stageData.AnswerIndex.x && yIndex == _stageData.AnswerIndex.y)
                {
                    cell.Animate(AnimationType.Bounce);
                    OnRightAnswer?.Invoke();
                    _particleSystem.transform.position = cell.transform.position;
                    _particleSystem.Play();
                }
                else
                    cell.Animate();
            }
        }

        private bool TryWorldToCell(Vector3 worldCoords, out int horizontalIndex, out int verticalIndex)
        {
            var coordsStart = _cells[0, 0].transform.position -
                              new Vector3(_gridHorizontalDist / 2, _gridVerticalDist / 2);
            horizontalIndex = (int)Mathf.Floor((worldCoords.x - coordsStart.x)/_gridHorizontalDist);
            verticalIndex = (int) Mathf.Floor((worldCoords.y - coordsStart.y)/_gridVerticalDist);

            if (horizontalIndex < 0 || verticalIndex < 0)
                return false;
            
            if (horizontalIndex > _stageData.GridData.GetLength(0) ||
                verticalIndex > _stageData.GridData.GetLength(1))
                return false;
            
            return true;
        }
    }
}
