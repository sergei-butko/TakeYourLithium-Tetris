using Tetris.Base;
using Zenject;

namespace Tetris.Zenject
{
    public static class ZenjectExtensions
    {
        /// <summary>
        /// Binds mediator as a transient object and adds it to TransientDisposables.
        /// </summary>
        /// <param name="container">DI Container.</param>
        /// <typeparam name="TMediator">Mediator type.</typeparam>
        public static void BindMediator<TMediator>(this DiContainer container)
            where TMediator : BaseMediator
        {
            container
                .Bind<TMediator>()
                .AsTransient()
                .OnInstantiated((context, instance) =>
                {
                    var mediatorDisposables = context.Container.Resolve<TransientDisposables>();
                    mediatorDisposables?.TrackDisposable((TMediator) instance);
                });
        }
    }
}