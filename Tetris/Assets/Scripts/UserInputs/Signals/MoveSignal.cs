using Tetris.Tetromino;
using UnityEngine;

namespace UserInputs.Signals
{
    /// <summary>
    /// Is fired by <see cref="InputsHandler"/> after user "Move" input performs.
    /// Is handled by <see cref="TetrominoComponent"/>.
    /// </summary>
    public class MoveSignal
    {
        public Vector2 Direction;

        public MoveSignal(Vector2 direction)
        {
            Direction = direction;
        }
    }
}