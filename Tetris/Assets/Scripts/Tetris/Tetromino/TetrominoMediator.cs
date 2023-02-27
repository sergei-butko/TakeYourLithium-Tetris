using Tetris.Base;
using Tetris.Tetromino.Signals;
using UniRx;
using Zenject;

namespace Tetris.Tetromino
{
    public class TetrominoMediator : BaseMediator<TetrominoModel>
    {
        [Inject]
        private SignalBus _signalBus;

        protected override void OnInitialized()
        {
            _signalBus
                .GetStream<TetrominoInitializingSignal>()
                .Subscribe(OnTetrominoInitializing)
                .AddTo(Disposables);
        }

        private void OnTetrominoInitializing(TetrominoInitializingSignal signal)
        {
            Model.tetrominoType = signal.TetrominoType;
            Model.tile = signal.Tile;
            Model.position = signal.SpawnPosition;
            
            Component.OnUpdate(Model);
        }
    }
}