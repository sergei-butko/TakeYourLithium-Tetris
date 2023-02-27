using UnityEngine;
using Zenject;

namespace Tetris.Base
{
    public abstract class BaseComponent<TModel, TMediator> : MonoBehaviour, IComponent<TModel>
        where TModel : BaseModel
        where TMediator : BaseMediator<TModel>
    {
        protected TMediator Mediator { get; private set; }

        [Inject]
        public virtual void Init(TMediator mediator)
        {
            Mediator = mediator;
            Mediator.InitMediator(GetModel(), component: this);
        }

        public virtual void OnUpdate(TModel model)
        {
        }

        public abstract TModel GetModel();

        protected virtual void OnDestroy()
        {
            Mediator?.Dispose();
            Mediator = null;
        }
    }
}