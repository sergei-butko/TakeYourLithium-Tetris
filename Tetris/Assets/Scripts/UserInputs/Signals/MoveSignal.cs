using Tetris.Tetromino;
using UnityEngine;

namespace UserInputs.Signals
{
    /// <summary>
    /// Is fired by <see cref="InputsHandler"/> after user "Move" input performs.
    /// Is handled by <see cref="TetrominoMediator"/>.
    /// </summary>
    public class MoveSignal
    {
        public Vector2Int Direction;

        public MoveSignal(Vector2Int direction)
        {
            Direction = direction;
        }
    }
}