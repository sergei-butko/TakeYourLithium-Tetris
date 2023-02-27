using Tetris.Board;
using Tetris.Tetromino;
using Tetris.Tetromino.Signals;
using UniRx;
using Zenject;

namespace Tetris.Zenject
{
    public class TetrisInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            Container.BindInterfacesAndSelfTo<TransientDisposables>().AsSingle();

            Container.Bind<CompositeDisposable>().AsTransient();

            InstallSignalsBindings();
            InstallMediatorsBindings();
        }

        private void InstallSignalsBindings()
        {
            Container.DeclareSignal<TetrominoInitializingSignal>();
        }

        private void InstallMediatorsBindings()
        {
            Container.BindMediator<BoardMediator>();
            Container.BindMediator<TetrominoMediator>();
        }
    }
}