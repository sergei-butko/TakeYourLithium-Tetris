using System.Collections.Generic;
using Models;
using UnityEngine;

namespace Tetris
{
    public class TetrominoPiece : MonoBehaviour
    {
        private Board _board;

        private TetrominoData _data;
        private IEnumerable<Vector3Int> _cells;
        private Vector3Int _position;

        public void Initialize(Board board, TetrominoData data, Vector3Int position)
        {
            _board = board;
            _data = data;
            _position = position;

            if (_cells == null)
            {
                var list = new List<Vector3Int>();
                foreach (var cell in _data.cells)
                {
                    list.Add((Vector3Int) cell);
                }

                _cells = list;
            }
        }

        public TetrominoData Data => _data;
        public IEnumerable<Vector3Int> Cells => _cells;
        public Vector3Int Position => _position;
    }
}