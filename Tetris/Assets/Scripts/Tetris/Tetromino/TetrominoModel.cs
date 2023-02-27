using System;
using System.Collections.Generic;
using Tetris.Base;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tetris.Tetromino
{
    [Serializable]
    public class TetrominoModel : BaseModel
    {
        public TetrominoType tetrominoType;
        public Tile tile;
        public IEnumerable<Vector2Int> cells;
        public Vector3Int position;
    }
}