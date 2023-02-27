using System;
using Tetris.Zenject;
using UniRx;
using Zenject;

namespace Tetris.Base
{
    public abstract class BaseMediator : ITransientDisposable
    {
        public event EventHandler OnDisposed;

        [Inject]
        protected readonly CompositeDisposable Disposables;

        public virtual void Dispose()
        {
            if (Disposables == null || Disposables.IsDisposed)
            {
                return;
            }

            Disposables.Dispose();
            OnDisposed?.Invoke(this, EventArgs.Empty);
        }
    }

    public abstract class BaseMediator<TModel> : BaseMediator
        where TModel : BaseModel
    {
        protected TModel Model { get; private set; }
        protected IComponent<TModel> Component { get; private set; }

        public void InitMediator(TModel model, IComponent<TModel> component)
        {
            Model = model;
            Component = component;

            OnInitialized();
        }

        protected virtual void OnInitialized() { }
    }
}
