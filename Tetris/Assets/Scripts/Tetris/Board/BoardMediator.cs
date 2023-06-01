using Tetris.Base;
using Tetris.Tetromino;
using Tetris.Tetromino.Signals;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

namespace Tetris.Board
{
    public class BoardMediator : BaseMediator<BoardModel>
    {
        [Inject]
        private SignalBus _signalBus;

        protected override void OnInitialized()
        {
        }

        public void SpawnTetromino(
            TetrominoType tetrominoType,
            Tile tile,
            Vector2Int spawnPosition)
        {
            var tetrominoInitializingSignal = new TetrominoInitializingSignal(tetrominoType, tile, spawnPosition);
            _signalBus.Fire(tetrominoInitializingSignal);
        }
    }
}