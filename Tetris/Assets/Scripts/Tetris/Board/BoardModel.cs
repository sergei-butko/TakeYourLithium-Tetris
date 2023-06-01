using System;
using Tetris.Base;
using UnityEngine;

namespace Tetris.Board
{
    [Serializable]
    public class BoardModel : BaseModel
    {
        public Vector2Int spawnPosition;
    }
}