using Tetris.Board;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tetris.Tetromino.Signals
{
    /// <summary>
    /// Is fired by <see cref="BoardMediator"/> when it is needed to spawn new tetromino.
    /// Is handled by <see cref="BoardMediator"/>.
    /// </summary>
    public class TetrominoInitializingSignal
    {
        public TetrominoType TetrominoType;
        public Tile Tile;
        public Vector2Int SpawnPosition;

        public TetrominoInitializingSignal(TetrominoType tetrominoType, Tile tile, Vector2Int spawnPosition)
        {
            TetrominoType = tetrominoType;
            Tile = tile;
            SpawnPosition = spawnPosition;
        }
    }
}