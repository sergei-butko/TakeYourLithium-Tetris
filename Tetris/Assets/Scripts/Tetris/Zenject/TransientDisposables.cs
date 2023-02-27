using System;
using System.Collections.Generic;

namespace Tetris.Zenject
{
    /// <summary>
    /// An util class, which stores Transient disposables, invokes Dispose
    /// on them on context disposed and listens to externally disposed events.
    /// </summary>
    public class TransientDisposables : IDisposable
    {
        private readonly List<ITransientDisposable> _transientDisposables = new ();

        public void Dispose()
        {
            _transientDisposables.ForEach(transientDisposable =>
            {
                transientDisposable.OnDisposed -= OnDisposedExternally;
                transientDisposable.Dispose();
            });

            _transientDisposables.Clear();
        }

        public void TrackDisposable(ITransientDisposable transientDisposable)
        {
            _transientDisposables.Add(transientDisposable);
            transientDisposable.OnDisposed += OnDisposedExternally;
        }

        private void OnDisposedExternally(object sender, EventArgs args)
        {
            if (sender is not ITransientDisposable transientDisposable) return;

            transientDisposable.OnDisposed -= OnDisposedExternally;
            if (_transientDisposables.Contains(transientDisposable))
            {
                _transientDisposables.Remove(transientDisposable);
            }
        }
    }
}