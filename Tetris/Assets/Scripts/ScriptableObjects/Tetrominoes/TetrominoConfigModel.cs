using System;
using Tetris.Tetromino;
using UnityEngine.Tilemaps;

namespace ScriptableObjects.Tetrominoes
{
    [Serializable]
    public class TetrominoConfigModel
    {
        public TetrominoType tetrominoType;
        public Tile tile;
    }
}