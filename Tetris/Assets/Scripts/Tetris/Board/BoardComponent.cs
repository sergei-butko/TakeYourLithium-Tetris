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
        private Vector3Int spawnPosition = new(-1, 8, 0);

        public override BoardModel GetModel()
        {
            return new BoardModel
            {
                spawnPosition = spawnPosition
            };
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