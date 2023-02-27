using Tetris.Board;
using Tetris.Tetromino;
using Tetris.Tetromino.Signals;
using UniRx;
using UserInputs;
using UserInputs.Signals;
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
            InstallServicesBindings();
            InstallMediatorsBindings();
        }

        private void InstallSignalsBindings()
        {
            Container.DeclareSignal<TetrominoInitializingSignal>();
            Container.DeclareSignal<RotateSignal>();
            Container.DeclareSignal<MoveSignal>();
        }

        private void InstallServicesBindings()
        {
            Container.BindInterfacesAndSelfTo<UserControls>().AsSingle();
            Container.BindInterfacesAndSelfTo<InputsHandler>().AsSingle();
        }

        private void InstallMediatorsBindings()
        {
            Container.BindMediator<BoardMediator>();
            Container.BindMediator<TetrominoMediator>();
        }
    }
}