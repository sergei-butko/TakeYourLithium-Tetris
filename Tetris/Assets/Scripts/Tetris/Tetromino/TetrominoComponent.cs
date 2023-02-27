using System.Collections.Generic;
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

        private IEnumerable<Vector2Int> _cells;
        private Vector3Int _position;

        private BoardComponent _board;
        private Tilemap _tilemap;

        public override TetrominoModel GetModel()
        {
            _cells ??= TetrominoesData.Cells[tetrominoType];

            return new TetrominoModel
            {
                tetrominoType = tetrominoType,
                tile = tile,
                cells = _cells,
                position = _position,
            };
        }

        public override void OnUpdate(TetrominoModel model)
        {
            base.OnUpdate(model);

            tetrominoType = model.tetrominoType;
            tile = model.tile;
            _cells = TetrominoesData.Cells[tetrominoType];
            _position = model.position;

            Set();
        }

        private void Awake()
        {
            _tilemap = GetComponentInChildren<Tilemap>();
        }

        private void Set()
        {
            foreach (var cell in _cells)
            {
                var tilePosition = (Vector3Int) cell + _position;
                _tilemap.SetTile(tilePosition, tile);
            }
        }

        private void Move(Vector2Int translation)
        {
            var newPosition = _position + (Vector3Int) translation;
        }

        private void Rotate()
        {
        }
    }
}