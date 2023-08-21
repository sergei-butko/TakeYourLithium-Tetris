using ScriptableObjects.Tetrominoes;
using Tetris.Base;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tetris.Board
{
    public class BoardComponent : BaseComponent<BoardModel, BoardMediator>
    {
        private readonly Vector2Int _boardSize = new(10, 20);

        [SerializeField]
        private TetrisConfig tetrisConfig;

        [SerializeField]
        private Vector2Int spawnPosition = new(-1, 8);

        public RectInt Bounds
        {
            get
            {
                var position = new Vector2Int(-_boardSize.x / 2, -_boardSize.y / 2);
                return new RectInt(position, _boardSize);
            }
        }

        public override BoardModel GetModel()
        {
            return new BoardModel
            {
                spawnPosition = spawnPosition
            };
        }

        public void SpawnTetromino()
        {
            Mediator.SpawnTetromino(tetrisConfig);
        }

        public void ClearLine(Tilemap tilemap)
        {
            var row = Bounds.yMin;
            while (row < Bounds.yMax)
            {
                if (IsLineFull(tilemap, row))
                {
                    LineClear(tilemap, row);
                }
                else
                {
                    row++;
                }
            }
        }

        private void Awake()
        {
            SpawnTetromino();
        }

        private bool IsLineFull(Tilemap tilemap, int row)
        {
            for (var col = Bounds.xMin; col < Bounds.xMax; col++)
            {
                var position = new Vector3Int(col, row, 0);

                if (!tilemap.HasTile(position))
                {
                    return false;
                }
            }

            return true;
        }

        private void LineClear(Tilemap tilemap, int row)
        {
            for (var col = Bounds.xMin; col < Bounds.xMax; col++)
            {
                var position = new Vector3Int(col, row, 0);
                tilemap.SetTile(position, null);
            }

            while (row < Bounds.yMax)
            {
                for (var col = Bounds.xMin; col < Bounds.xMax; col++)
                {
                    var position = new Vector3Int(col, row + 1, 0);
                    var tileAbove = tilemap.GetTile(position);

                    position = new Vector3Int(col, row, 0);
                    tilemap.SetTile(position, tileAbove);
                }

                row++;
            }
        }
    }
}