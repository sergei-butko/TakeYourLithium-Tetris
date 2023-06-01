using System;
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
        public Vector2Int[] cells;
        public Vector2Int[,] wallKicks;
        public Vector2Int position;
        public int rotationIndex;
    }
}