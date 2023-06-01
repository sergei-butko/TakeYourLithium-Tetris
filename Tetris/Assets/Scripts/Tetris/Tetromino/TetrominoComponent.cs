using Attributes;
using Tetris.Base;
using Tetris.Utils;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tetris.Tetromino
{
    public class TetrominoComponent : BaseComponent<TetrominoModel, TetrominoMediator>
    {
        private readonly Vector2Int _boardSize = new(10, 20);

        [SerializeField, InspectorReadOnly]
        private TetrominoType tetrominoType = TetrominoType.Ghost;

        [SerializeField, InspectorReadOnly]
        private Tile tile;

        private Vector2Int[] _cells;
        private Vector2Int[,] _wallKicks;
        private Vector2Int _position;
        private int _rotationIndex;

        public Tilemap Tilemap { get; private set; }

        public RectInt Bounds
        {
            get
            {
                var position = new Vector2Int(-_boardSize.x / 2, -_boardSize.y / 2);
                return new RectInt(position, _boardSize);
            }
        }

        public override TetrominoModel GetModel()
        {
            _cells ??= TetrominoesData.Cells[tetrominoType];
            _wallKicks ??= TetrominoesData.GetWallKicks(tetrominoType);

            return new TetrominoModel
            {
                tetrominoType = tetrominoType,
                tile = tile,
                cells = _cells,
                position = _position,
                rotationIndex = _rotationIndex,
            };
        }

        public override void OnUpdate(TetrominoModel model)
        {
            base.OnUpdate(model);

            tetrominoType = model.tetrominoType;
            tile = model.tile;
            _cells = model.cells;
            _position = model.position;
            _rotationIndex = model.rotationIndex;

            Set();
        }

        public void Set()
        {
            foreach (var cell in _cells)
            {
                var tilePosition = cell + _position;
                Tilemap.SetTile((Vector3Int) tilePosition, tile);
            }
        }

        public void Clear()
        {
            foreach (var cell in _cells)
            {
                var tilePosition = cell + _position;
                Tilemap.SetTile((Vector3Int) tilePosition, null);
            }
        }

        private void Awake()
        {
            Tilemap = GetComponentInChildren<Tilemap>();
        }
    }
}