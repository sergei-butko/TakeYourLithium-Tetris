using System;
using Tetris.Tetromino;
using UnityEngine.Tilemaps;

namespace ScriptableObjects.Tetrominoes
{
    [Serializable]
    public class TetrominoConfigModel
    {
        public TetrominoType type;
        public Tile tile;
    }
}