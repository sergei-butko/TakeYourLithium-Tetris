using ScriptableObjects.Tetrominoes;
using Tetris.Base;
using Tetris.Tetromino.Signals;
using UnityEngine;
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

        public void SpawnTetromino(TetrisConfig tetrisConfig)
        {
            var tetrominoIndex = Random.Range(0, tetrisConfig.tetrominoes.Count);
            
            var tetrominoInitializingSignal = new TetrominoInitializingSignal(tetrisConfig, tetrominoIndex);
            _signalBus.Fire(tetrominoInitializingSignal);
        }
    }
}