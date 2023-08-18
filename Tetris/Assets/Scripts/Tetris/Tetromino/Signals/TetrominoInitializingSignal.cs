using ScriptableObjects.Tetrominoes;
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
        public TetrominoType Type;
        public Tile Tile;
        public Vector2Int SpawnPosition;
        public float StepDelay;
        public float LockDelay;

        public TetrominoInitializingSignal(TetrisConfig tetrisConfig, int tetrominoIndex)
        {
            var tetromino = tetrisConfig.tetrominoes[tetrominoIndex];
            Type = tetromino.type;
            Tile = tetromino.tile;
            SpawnPosition = tetrisConfig.spawnPosition;
            StepDelay = tetrisConfig.stepDelay;
            LockDelay = tetrisConfig.lockDelay;
        }
    }
}