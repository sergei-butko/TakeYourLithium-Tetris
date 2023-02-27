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
        public BoardComponent BoardComponent;
        public TetrominoType TetrominoType;
        public Tile Tile;
        public Vector3Int SpawnPosition;

        public TetrominoInitializingSignal(
            BoardComponent boardComponent, TetrominoType tetrominoType, Tile tile, Vector3Int spawnPosition)
        {
            BoardComponent = boardComponent;
            TetrominoType = tetrominoType;
            Tile = tile;
            SpawnPosition = spawnPosition;
        }
    }
}