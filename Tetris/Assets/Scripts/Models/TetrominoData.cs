using System;
using System.Collections.Generic;
using Enums;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Models
{
    [Serializable]
    public class TetrominoData
    {
        public Tetromino tetromino;
        public Tile tile;
        public IEnumerable<Vector2Int> cells;

        public void Initialize()
        {
            cells = Data.Cells[tetromino];
        }
    }
}