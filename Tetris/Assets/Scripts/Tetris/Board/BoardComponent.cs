using Tetris.Base;
using UnityEngine;

namespace Tetris.Board
{
    public class BoardComponent : BaseComponent<BoardModel, BoardMediator>
    {
        [SerializeField]
        private Vector3Int spawnPosition = new(-1, 8, 0);

        public override BoardModel GetModel()
        {
            return new BoardModel
            {
                spawnPosition = spawnPosition
            };
        }
    }
}