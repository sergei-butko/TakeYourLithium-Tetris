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

        [Inject]
        public void Init(SignalBus signalBus, UserControls controls)
        {
            _signalBus = signalBus;
            _controls = controls;

            _controls.Tetris.Enable();

            _controls.Tetris.MoveRight.performed += OnMoveRight;
            _controls.Tetris.MoveLeft.performed += OnMoveLeft;
            _controls.Tetris.Rotate.performed += OnRotate;
        }

        public void Dispose()
        {
            _controls.Tetris.Disable();
        }

        private void OnMoveRight(InputAction.CallbackContext context)
        {
            var direction = Vector2.right;
            var moveSignal = new MoveSignal(direction);
            _signalBus.Fire(moveSignal);
        }

        private void OnMoveLeft(InputAction.CallbackContext context)
        {
            var direction = Vector2.left;
            var moveSignal = new MoveSignal(direction);
            _signalBus.Fire(moveSignal);
        }

        private void OnRotate(InputAction.CallbackContext context)
        {
            _signalBus.Fire(new RotateSignal());
        }
    }
}