using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UserInputs.Signals;
using Zenject;

namespace UserInputs
{
    public class InputsHandler : IDisposable
    {
        private SignalBus _signalBus;
        private UserControls _controls;

        private const float AccumulatorMaxAbsValue = 20f;

        private float _horizontalInputAccumulator;
        private float _verticalInputAccumulator;

        private bool _isHorizontalDirectionChanged;

        [Inject]
        public void Init(SignalBus signalBus, UserControls controls)
        {
            _signalBus = signalBus;
            _controls = controls;

            _controls.Tetris.Enable();

            _controls.Tetris.Move.performed += OnMove;
            _controls.Tetris.Rotate.performed += OnRotate;
        }

        public void Dispose()
        {
            _controls.Tetris.Disable();
        }

        private void OnMove(InputAction.CallbackContext context)
        {
            var delta = context.ReadValue<Vector2>();

            if (delta.y == 0)
            {
                if (Mathf.Sign(delta.x * _horizontalInputAccumulator) > 0)
                {
                    _horizontalInputAccumulator += delta.x;

                    if (Mathf.Abs(_horizontalInputAccumulator) < AccumulatorMaxAbsValue) return;

                    switch (delta.x)
                    {
                        case > 0:
                            FireMoveSignal(Vector2Int.right);
                            break;
                        case < 0:
                            FireMoveSignal(Vector2Int.left);
                            break;
                    }

                    return;
                }

                _horizontalInputAccumulator = 0;
            }

            if (delta is {x: 0, y: < 0})
            {
                _verticalInputAccumulator += delta.y;

                if (Mathf.Abs(_verticalInputAccumulator) < AccumulatorMaxAbsValue) return;

                FireMoveSignal(Vector2Int.down);
                _verticalInputAccumulator = 0;
            }
        }

        private void OnRotate(InputAction.CallbackContext context)
        {
            _signalBus.Fire(new RotateSignal());
        }

        private void FireMoveSignal(Vector2Int direction)
        {
            var moveSignal = new MoveSignal(direction);
            _signalBus.Fire(moveSignal);
        }
    }
}