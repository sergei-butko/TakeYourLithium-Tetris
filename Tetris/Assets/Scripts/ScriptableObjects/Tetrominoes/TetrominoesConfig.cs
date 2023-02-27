using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects.Tetrominoes
{
    [CreateAssetMenu(menuName = "Tetris Configs/Tetrominoes Config", order = 1)]
    public class TetrominoesConfig : ScriptableObject
    {
        public List<TetrominoConfigModel> tetrominoes;
    }
}