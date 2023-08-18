using ScriptableObjects.Tetrominoes;
using Tetris.Base;
using UnityEngine;

namespace Tetris.Board
{
    public class BoardComponent : BaseComponent<BoardModel, BoardMediator>
    {
        [SerializeField]
        private TetrisConfig tetrisConfig;

        [SerializeField]
        private Vector2Int spawnPosition = new(-1, 8);

        public override BoardModel GetModel()
        {
            return new BoardModel
            {
                spawnPosition = spawnPosition
            };
        }

        public void SpawnTetromino()
        {
            Mediator.SpawnTetromino(tetrisConfig);
        }

        private void Awake()
        {
            SpawnTetromino();
        }
    }
}