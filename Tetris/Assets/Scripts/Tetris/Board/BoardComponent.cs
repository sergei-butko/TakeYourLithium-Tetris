using ScriptableObjects.Tetrominoes;
using Tetris.Base;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Tetris.Board
{
    public class BoardComponent : BaseComponent<BoardModel, BoardMediator>
    {
        [SerializeField]
        private TetrominoesConfig tetrominoesConfig;

        [SerializeField]
        private Vector2Int spawnPosition = new(-1, 8);

        public override BoardModel GetModel()
        {
            return new BoardModel
            {
                spawnPosition = spawnPosition
            };
        }

        private void Awake()
        {
            SpawnTetromino();
        }

        private void SpawnTetromino()
        {
            var tetrominoes = tetrominoesConfig.tetrominoes;
            var randomIndex = Random.Range(0, tetrominoes.Count);
            var tetrominoConfigModel = tetrominoes[randomIndex];

            Mediator.SpawnTetromino(tetrominoConfigModel.tetrominoType, tetrominoConfigModel.tile, spawnPosition);
        }
    }
}