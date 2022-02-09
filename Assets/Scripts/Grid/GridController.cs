using AmayaTest.Data;
using UnityEngine;

namespace AmayaTest.Grid
{
    public class GridController : MonoBehaviour
    {
        [SerializeField] 
        private Cell _cellPrefab;
        
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
        }
        

        public void SetStage(StageData newStage)
        {
            if (!_isInited)
            {
                Init();
            }
            _stageData = newStage;
            DrawStage();
        }

        private void DrawStage()
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
    }
}
