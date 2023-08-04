using Tetris.Base;
using Tetris.Tetromino;
using Tetris.Tetromino.Signals;
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

        public void SpawnTetromino(TetrominoType tetrominoType, Tile tile)
        {
            var tetrominoInitializingSignal = new TetrominoInitializingSignal(tetrominoType, tile, Model.spawnPosition);
            _signalBus.Fire(tetrominoInitializingSignal);
        }
    }
}