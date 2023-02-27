using System.Collections.Generic;
using Tetris.Tetromino;
using UnityEngine;

namespace Tetris.Utils
{
    public static class TetrominoesData
    {
        private static readonly float Cos = Mathf.Cos(Mathf.PI / 2f);
        private static readonly float Sin = Mathf.Sin(Mathf.PI / 2f);

        public static readonly float[] RotationMatrix = {Cos, Sin, -Sin, Cos};

        public static readonly Dictionary<TetrominoType, IEnumerable<Vector2Int>> Cells = new()
        {
            {TetrominoType.I, new Vector2Int[] {new(-1, 1), new(0, 1), new(1, 1), new(2, 1)}},
            {TetrominoType.J, new Vector2Int[] {new(-1, 1), new(-1, 0), new(0, 0), new(1, 0)}},
            {TetrominoType.L, new Vector2Int[] {new(1, 1), new(-1, 0), new(0, 0), new(1, 0)}},
            {TetrominoType.O, new Vector2Int[] {new(0, 1), new(1, 1), new(0, 0), new(1, 0)}},
            {TetrominoType.S, new Vector2Int[] {new(0, 1), new(1, 1), new(-1, 0), new(0, 0)}},
            {TetrominoType.T, new Vector2Int[] {new(0, 1), new(-1, 0), new(0, 0), new(1, 0)}},
            {TetrominoType.Z, new Vector2Int[] {new(-1, 1), new(0, 1), new(0, 0), new(1, 0)}},
        };

        public static readonly Dictionary<TetrominoType, Vector2Int[,]> WallKicks = new()
        {
            {TetrominoType.I, WallKicksI},
            {TetrominoType.J, WallKicksJLOSTZ},
            {TetrominoType.L, WallKicksJLOSTZ},
            {TetrominoType.O, WallKicksJLOSTZ},
            {TetrominoType.S, WallKicksJLOSTZ},
            {TetrominoType.T, WallKicksJLOSTZ},
            {TetrominoType.Z, WallKicksJLOSTZ},
        };

        private static readonly Vector2Int[,] WallKicksI =
        {
            {new(0, 0), new(-2, 0), new(1, 0), new(-2, -1), new(1, 2)},
            {new(0, 0), new(2, 0), new(-1, 0), new(2, 1), new(-1, -2)},
            {new(0, 0), new(-1, 0), new(2, 0), new(-1, 2), new(2, -1)},
            {new(0, 0), new(1, 0), new(-2, 0), new(1, -2), new(-2, 1)},
            {new(0, 0), new(2, 0), new(-1, 0), new(2, 1), new(-1, -2)},
            {new(0, 0), new(-2, 0), new(1, 0), new(-2, -1), new(1, 2)},
            {new(0, 0), new(1, 0), new(-2, 0), new(1, -2), new(-2, 1)},
            {new(0, 0), new(-1, 0), new(2, 0), new(-1, 2), new(2, -1)},
        };

        private static readonly Vector2Int[,] WallKicksJLOSTZ =
        {
            {new(0, 0), new(-1, 0), new(-1, 1), new(0, -2), new(-1, -2)},
            {new(0, 0), new(1, 0), new(1, -1), new(0, 2), new(1, 2)},
            {new(0, 0), new(1, 0), new(1, -1), new(0, 2), new(1, 2)},
            {new(0, 0), new(-1, 0), new(-1, 1), new(0, -2), new(-1, -2)},
            {new(0, 0), new(1, 0), new(1, 1), new(0, -2), new(1, -2)},
            {new(0, 0), new(-1, 0), new(-1, -1), new(0, 2), new(-1, 2)},
            {new(0, 0), new(-1, 0), new(-1, -1), new(0, 2), new(-1, 2)},
            {new(0, 0), new(1, 0), new(1, 1), new(0, -2), new(1, -2)},
        };
    }
}