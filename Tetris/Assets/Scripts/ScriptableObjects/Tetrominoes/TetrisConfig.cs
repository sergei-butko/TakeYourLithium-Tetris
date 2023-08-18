using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects.Tetrominoes
{
    [CreateAssetMenu(menuName = "Tetris Configs/Tetris Config", order = 1)]
    public class TetrisConfig : ScriptableObject
    {
        public List<TetrominoConfigModel> tetrominoes;
        public Vector2Int spawnPosition = new(-1, 8);
        public float stepDelay = 1f;
        public float lockDelay = 0.5f;
    }
}