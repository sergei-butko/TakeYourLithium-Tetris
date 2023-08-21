using Attributes;
using Tetris.Base;
using Tetris.Board;
using Tetris.Utils;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tetris.Tetromino
{
    public class TetrominoComponent : BaseComponent<TetrominoModel, TetrominoMediator>
    {
        [SerializeField, InspectorReadOnly]
        private TetrominoType tetrominoType = TetrominoType.Ghost;

        [SerializeField, InspectorReadOnly]
        private Tile tile;

        private BoardComponent _boardComponent;
        private Tilemap _tilemap;

        private Vector2Int[] _cells;
        private Vector2Int[,] _wallKicks;
        private Vector2Int _position;
        private int _rotationIndex;

        private float _stepDelay;
        private float _lockDelay;

        private float _stepTime;
        private float _lockTime;

        public BoardComponent Board
        {
            get
            {
                if (_boardComponent == null)
                {
                    _boardComponent = GetComponent<BoardComponent>();
                }

                return _boardComponent;
            }
        }

        public Tilemap Tilemap
        {
            get
            {
                if (_tilemap == null)
                {
                    _tilemap = GetComponentInChildren<Tilemap>();
                }

                return _tilemap;
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
                stepDelay = _stepDelay,
                lockDelay = _lockDelay,
                lockTime = _lockTime,
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
            _stepDelay = model.stepDelay;
            _lockDelay = model.lockDelay;
            _lockTime = model.lockTime;

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
            _stepTime = Time.time + _stepDelay;
            _lockTime = 0f;
        }

        private void Update()
        {
            Clear();

            _lockTime += Time.deltaTime;

            if (Time.time >= _stepTime && Time.time != 0)
            {
                Step();
            }

            Set();
        }

        private void Step()
        {
            _stepTime = Time.time + _stepDelay;

            Mediator.Move(_position + Vector2Int.down);

            if (_lockTime >= _lockDelay)
            {
                Lock();
            }
        }

        private void Lock()
        {
            Set();
            Board.ClearLine(Tilemap);
            Board.SpawnTetromino();
        }
    }
}