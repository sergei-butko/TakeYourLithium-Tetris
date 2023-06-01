using Extensions;
using Tetris.Base;
using Tetris.Tetromino.Signals;
using Tetris.Utils;
using UniRx;
using UnityEngine;
using UserInputs.Signals;
using Zenject;

namespace Tetris.Tetromino
{
    public class TetrominoMediator : BaseMediator<TetrominoModel>
    {
        [Inject]
        private SignalBus _signalBus;

        protected override void OnInitialized()
        {
            _signalBus
                .GetStream<TetrominoInitializingSignal>()
                .Subscribe(OnTetrominoInitializing)
                .AddTo(Disposables);
            _signalBus
                .GetStream<MoveSignal>()
                .Subscribe(OnMove)
                .AddTo(Disposables);
            _signalBus
                .GetStream<RotateSignal>()
                .Subscribe(OnRotate)
                .AddTo(Disposables);
        }

        private void OnTetrominoInitializing(TetrominoInitializingSignal signal)
        {
            Model.tetrominoType = signal.TetrominoType;
            Model.tile = signal.Tile;
            Model.cells = TetrominoesData.Cells[signal.TetrominoType];
            Model.wallKicks = TetrominoesData.GetWallKicks(signal.TetrominoType);
            Model.position = signal.SpawnPosition;
            Model.rotationIndex = 0;

            Component.OnUpdate(Model);
        }

        private void OnMove(MoveSignal signal)
        {
            var tetrominoComponent = (TetrominoComponent) Component;

            tetrominoComponent.Clear();

            Move(Model.position + signal.Direction);

            tetrominoComponent.Set();
        }

        private void OnRotate(RotateSignal signal)
        {
            var tetrominoComponent = (TetrominoComponent) Component;

            tetrominoComponent.Clear();

            var previousRotationIndex = Model.rotationIndex;
            Model.rotationIndex = (Model.rotationIndex + 1).Wrap(0, 4);

            ApplyRotationMatrix(1);

            if (!TestWallKicks(Model.rotationIndex))
            {
                Model.rotationIndex = previousRotationIndex;
                ApplyRotationMatrix(-1);
            }

            Component.OnUpdate(Model);

            tetrominoComponent.Set();
        }

        private bool Move(Vector2Int newPosition)
        {
            if (!IsValidPosition(newPosition)) return false;

            Model.position = newPosition;
            Component.OnUpdate(Model);
            return true;
        }

        private void ApplyRotationMatrix(int direction)
        {
            for (var i = 0; i < Model.cells.Length; i++)
            {
                var cell = (Vector2) Model.cells[i];

                var x = 0;
                var y = 0;

                switch (Model.tetrominoType)
                {
                    case TetrominoType.I:
                        break;
                    case TetrominoType.O:
                        cell.x -= 0.5f;
                        cell.y -= 0.5f;
                        x = Mathf.CeilToInt(
                            cell.x * TetrominoesData.RotationMatrix[0] * direction +
                            cell.y * TetrominoesData.RotationMatrix[1] * direction);
                        y = Mathf.CeilToInt(
                            cell.x * TetrominoesData.RotationMatrix[2] * direction +
                            cell.y * TetrominoesData.RotationMatrix[3] * direction);
                        break;
                    default:
                        x = Mathf.RoundToInt(
                            cell.x * TetrominoesData.RotationMatrix[0] * direction +
                            cell.y * TetrominoesData.RotationMatrix[1] * direction);
                        y = Mathf.RoundToInt(
                            cell.x * TetrominoesData.RotationMatrix[2] * direction +
                            cell.y * TetrominoesData.RotationMatrix[3] * direction);
                        break;
                }

                Model.cells[i] = new Vector2Int(x, y);
            }
        }

        private bool IsValidPosition(Vector2Int position)
        {
            var tetrominoComponent = (TetrominoComponent) Component;

            foreach (var cell in Model.cells)
            {
                var tilePosition = cell + position;

                if (!tetrominoComponent.Bounds.Contains(tilePosition) ||
                    tetrominoComponent.Tilemap.HasTile((Vector3Int) tilePosition))
                {
                    return false;
                }
            }

            return true;
        }

        private bool TestWallKicks(int rotationIndex)
        {
            for (var i = 0; i < Model.wallKicks.GetLength(1); i++)
            {
                var newPosition = Model.position + Model.wallKicks[rotationIndex, i];

                if (Move(newPosition))
                {
                    return true;
                }
            }

            return false;
        }
    }
}