using System;

namespace Tetris.Zenject
{
    /// <summary>
    /// Must be implemented if we need disposable object Binded as Transient to Zenject.s
    /// </summary>
    public interface ITransientDisposable : IDisposable
    {
        event EventHandler OnDisposed;
    }
}